using AwesomeBlazor.Services.Abstractions;
using AwesomeBlazor.Services.Models.Movies;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;
using AwesomeBlazor.Services.Models;
using AwesomeBlazor.Services.Models.Trending;

namespace AwesomeBlazor.Services.Implementations
{
    public class TMDbService : ITMDbService
    {
        private string GetPopularUrl(int page, string lang = "it-IT") => $"movie/popular?language={lang}&page={page}";
        private string GetLanguages() => "configuration/languages";
        private string GetTranding(string mediaType, string timeWindow, int page) => $"trending/{mediaType}/{timeWindow}?page={page}";

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

        public async Task<PagedResult<Movie>> GetTrandingAsync(TrendingFilter filter, int page = 1, CancellationToken cancellationToken = default)
        {
            return await client.GetFromJsonAsync<PagedResult<Movie>>(GetTranding(filter.Type, filter.TimeWindow, page), cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
