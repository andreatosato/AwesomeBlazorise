using AwesomeBlazor.Services.Abstractions;
using AwesomeBlazor.Services.Models.Movies;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace AwesomeBlazor.Services.Implementations
{
    public class TMDbService : ITMDbService
    {
        private static string ApiKey = "5d86fbbd03aaada63651d561aa926955";
        private string GetPopularUrl(int page, string lang = "it-IT") => $"movie/popular?api_key={ApiKey}&language={lang}&page={page}";
        private readonly HttpClient client;
        public TMDbService(IHttpClientFactory factory)
        {
            client = factory.CreateClient("themoviedb"); // new TMDbClient("5d86fbbd03aaada63651d561aa926955");
        }

        // https://github.com/LordMike/TMDbLib/
        public async Task<PagedResult<Movie>> GetMoviePopularAsync(int page = 0, CancellationToken cancellationToken = default)
        {
            var result =  await client.GetFromJsonAsync<PagedResult<Movie>>(GetPopularUrl(page));

           
            //result.FromSearch(search);
            //foreach(var m in search.Results)
            //{
            //    var movie = await client.GetMovieAsync(m.Id, MovieMethods.ReleaseDates|MovieMethods.Images|MovieMethods.Recommendations|MovieMethods.Translations);
            //    result.Results.Add(movie);
            //}
            return result;
        }
    }
}
