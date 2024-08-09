using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Domain.Interfaces
{
    public interface IMovieRepository
    {
        public Task<Movie> AddAsync(Movie movie);
    }
}
