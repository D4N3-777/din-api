﻿using AutoMapper.Configuration;
using Din.Application.WebAPI.Accounts.Requests;
using Din.Application.WebAPI.Accounts.Responses;
using Din.Application.WebAPI.Querying;
using Din.Domain.Models.Entities;
using Din.Domain.Models.Querying;
using Din.Domain.Queries.Querying;
using Microsoft.AspNetCore.JsonPatch;

namespace Din.Application.WebAPI.Accounts.Mapping
{
    public class AccountsMappingProfile : MapperConfigurationExpression
    {
        public AccountsMappingProfile()
        {
            CreateMap<QueryParametersRequest, QueryParameters<Account>>()
                .ConvertUsing<ToQueryParametersConverter<Account>>();
            CreateMap<QueryParametersRequest, QueryParameters<AddedContent>>()
                .ConvertUsing<ToQueryParametersConverter<AddedContent>>();

            CreateMap<QueryResult<Account>, QueryResponse<Account>>();
            CreateMap<QueryResult<AddedContent>, QueryResponse<AddedContent>>();

            CreateMap<AccountRequest, Account>();
            CreateMap<Account, AccountResponse>();
            CreateMap<JsonPatchDocument<AccountRequest>, JsonPatchDocument<Account>>();
        }
    }
}
