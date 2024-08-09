using ApiMovies.Infraestructure.Data.Dtos;
using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> AddAsync(CreateMovieDto createMovieDto);
    }
}
