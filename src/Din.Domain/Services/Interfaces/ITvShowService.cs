﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Din.Domain.Clients.ResponseObjects;
using Din.Domain.Models.Dtos;
using TMDbLib.Objects.Search;

namespace Din.Domain.Services.Interfaces
{
    public interface ITvShowService
    {
        Task<IEnumerable<TvShowDto>> GetAllTvShowsAsync();

        Task<TvShowDto> GetTvShowByIdAsync(int id);

        /// <summary>
        /// Search Tv Shows with a specific query.
        /// </summary>
        /// <param name="query">The Tv Show title or a part of it.</param>
        /// <returns>ViewModel containing collections of existing movies and query results.</returns>
        Task<IEnumerable<SearchTv>> SearchTvShowAsync(string query);

        /// <summary>
        /// Adds TvShow to the system.
        /// </summary>
        /// <param name="tvShow">The TvShow object that needs to be added.</param>
        /// <param name="id">The account id of the current session.</param>
        /// <returns>The status result.</returns>
        Task<TcTvShow> AddTvShowAsync(SearchTv tvShow, Guid id);
        /// <summary>
        /// Get the MediaSystem tvShow release calendar.
        /// </summary>
        /// <returns>ViewModel containing calendar data.</returns>
        Task<IEnumerable<CalendarItemDto>> GetTvShowCalendarAsync(DateTime start, DateTime end);

        Task<IEnumerable<QueueDto>> GetTvShowQueueAsync();
    }
}