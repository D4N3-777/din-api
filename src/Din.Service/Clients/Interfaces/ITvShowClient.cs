﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Din.Service.Clients.RequestObjects;
using Din.Service.Clients.ResponseObjects;

namespace Din.Service.Clients.Interfaces
{
    public interface ITvShowClient : IContentClient
    {
        Task<IEnumerable<TcTvShow>> GetCurrentTvShowsAsync();
        Task<TcTvShow> GetTvShowByIdAsync(int id);
        Task<(bool status, int systemId)> AddTvShowAsync(TcRequest tvShow);
    }
}
