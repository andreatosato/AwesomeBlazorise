using AwesomeBlazor.Services.Models.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeBlazor.Services.Abstractions
{
    public interface ITMDbService
    {
        Task<PagedResult<Movie>> GetMoviePopularAsync(int page = 0, CancellationToken cancellationToken = default);
    }
}
