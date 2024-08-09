using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Utility.Interfaces
{
    public interface IMovieValidationService
    {
        Task<List<MovieGenre>> GetValidGenresAsync(IEnumerable<int> genreIds);
        Task<List<MovieActor>> GetValidActorsAsync(IEnumerable<int> actorIds);
    }
}
