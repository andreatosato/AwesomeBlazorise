﻿using AwesomeBlazor.Services.Abstractions;
using AwesomeBlazor.Services.Models.Movies;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Collections.Generic;
using AwesomeBlazor.Services.Models;

namespace AwesomeBlazor.Services.Implementations
{
    public class TMDbService : ITMDbService
    {
        private string GetPopularUrl(int page, string lang = "it-IT") => $"movie/popular?language={lang}&page={page}";
        private string GetLanguages() => "/configuration/languages";

        private readonly HttpClient client;
        public TMDbService(IHttpClientFactory factory)
        {
            client = factory.CreateClient("themoviedb");
        }

        public async Task<PagedResult<Movie>> GetMoviePopularAsync(int page = 1, CancellationToken cancellationToken = default)
        {
            return await client.GetFromJsonAsync<PagedResult<Movie>>(GetPopularUrl(page), cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<Language[]> GetAvailableLanguages(CancellationToken cancellationToken = default)
        {
            return await client.GetFromJsonAsync<Language[]>(GetLanguages(), cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
