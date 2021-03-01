using AwesomeBlazor.Services.Models;
using AwesomeBlazor.Services.Models.Movies;
using AwesomeBlazor.Services.Models.Trending;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeBlazor.Services.Abstractions
{
    public interface ITMDbService
    {
        Task<PagedResult<Movie>> GetMoviePopularAsync(int page = 1, CancellationToken cancellationToken = default);
        Task<Language[]> GetAvailableLanguages(CancellationToken cancellationToken = default);

        Task<PagedResult<Movie>> GetTrandingAsync(TrendingFilter filter, int page = 1, CancellationToken cancellationToken = default);
    }
}
