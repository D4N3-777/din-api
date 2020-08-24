﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Models.Querying;
using Din.Infrastructure.DataAccess.Querying;
using Din.Infrastructure.DataAccess.Repositories.Abstractions;
using Din.Infrastructure.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Din.Infrastructure.DataAccess.Repositories.Concrete
{
    public class AddedContentRepository : BaseRepository, IAddedContentRepository
    {
        public AddedContentRepository(DinContext context) : base(context)
        {
        }

        public Task<List<AddedContent>> GetAddedContentByAccountId(Guid id, QueryParameters queryParameters, AddedContentFilters filters,
            CancellationToken cancellationToken)
        {
            var query = Context.AddedContent.Where(ac => ac.AccountId.Equals(id));

            return filters.Type.HasValue
                ? query.Where(ac => ac.Type.Equals(filters.Type))
                    .ToListAsync(queryParameters, filters, cancellationToken)
                : query.ToListAsync(queryParameters, filters, cancellationToken);
        }

        public Task<int> Count(Guid id, AddedContentFilters filters, CancellationToken cancellationToken)
        {
            var query = Context.AddedContent.Where(ac => ac.AccountId.Equals(id));

            return filters.Type.HasValue
                ? query.Where(ac => ac.Type.Equals(filters.Type)).ApplyFilters(filters).CountAsync(cancellationToken)
                : query.ApplyFilters(filters).CountAsync(cancellationToken);
        }
    }
}
