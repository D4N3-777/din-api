﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Din.Domain.Context;
using Din.Domain.Exceptions.Concrete;
using Din.Domain.Helpers;
using Din.Domain.Managers.Interfaces;
using Din.Domain.Models.Entities;
using Din.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;
using BC = BCrypt.Net.BCrypt;


namespace Din.Domain.Commands.Authentication
{
    public class SendAuthorizationCodeCommandHandler : IRequestHandler<SendAuthorizationCodeCommand>
    {
        private readonly IAccountRepository _repository;
        private readonly IEmailManager _emailManager;
        private readonly IRequestContext _context;

        public SendAuthorizationCodeCommandHandler(IAccountRepository repository, IEmailManager emailManager,
            IRequestContext context)
        {
            _repository = repository;
            _emailManager = emailManager;
            _context = context;
        }

        public async Task<Unit> Handle(SendAuthorizationCodeCommand request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetAccountByEmail(request.Email, cancellationToken) ??
                          throw new NotFoundException("There is no account registered by that email", new { request.Email });

            var authorizationCode = RandomCodeGenerator.GenerateRandomCode(30, false);

            account.Codes.Add(new AccountAuthorizationCode
                {
                    Account = account,
                    Active = true,
                    Code = BC.HashPassword(authorizationCode),
                    Generated = DateTime.Now
                }
            );

            await _emailManager.SendAuthorizationCode(
                request.Email,
                account.Username,
                authorizationCode,
                _context.GetUserAgentAsString(),
                _context.GetRequestIpAsString(),
                cancellationToken
            );

            _repository.Update(account);

            return Unit.Value;
        }
    }
}