using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Interfaces
{
    public interface IGenreService
    {
        Task CreateGenreAsync(Genre genre);
        Task<IEnumerable<Genre>> GetAllGenreAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
    }
}
