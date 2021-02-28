using AwesomeBlazor.Services.Models;
using AwesomeBlazor.Services.Models.Movies;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeBlazor.Services.Abstractions
{
    public interface ITMDbService
    {
        Task<PagedResult<Movie>> GetMoviePopularAsync(int page = 1, CancellationToken cancellationToken = default);
        Task<Language[]> GetAvailableLanguages(CancellationToken cancellationToken = default);
    }
}
