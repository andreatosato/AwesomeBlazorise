using AwesomeBlazor.Services.Abstractions;
using AwesomeBlazor.Services.Models.Movies;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;
using AwesomeBlazor.Services.Models;
using AwesomeBlazor.Services.Models.Trending;
using System.Text.Json;

namespace AwesomeBlazor.Services.Implementations
{
    public class TMDbService : ITMDbService
    {
        private string GetPopularUrl(int page, string lang = "it-IT") => $"movie/popular?language={lang}&page={page}";
        private string GetDiscoverUrl(int page, string sortby, string lang = "it-IT") => $"discover/movie?language={lang}&page={page}&sort_by={sortby}";        
        private string GetLanguages() => "configuration/languages";
        private string GetTranding(string mediaType, string timeWindow, int page) => $"trending/{mediaType}/{timeWindow}?page={page}";
        private string GetMovieById(long movieId, string lang = "it-IT") => $"movie/{(int)movieId}?language={lang}";


        private readonly HttpClient client;
        public TMDbService(IHttpClientFactory factory)
        {
            client = factory.CreateClient("themoviedb");
        }

        public async Task<Movie> GetMovieAsync(long movieId, CancellationToken cancellationToken = default)
        {
            return await client.GetFromJsonAsync<Movie>(GetMovieById(movieId), cancellationToken: cancellationToken).ConfigureAwait(false);
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

        public async Task<PagedResult<Movie>> GetOrderByVoteCountAsync(int page = 1, CancellationToken cancellationToken = default)
        {
            return await client.GetFromJsonAsync<PagedResult<Movie>>(GetDiscoverUrl(page, "vote_count.desc"), cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
