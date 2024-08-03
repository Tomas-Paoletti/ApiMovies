using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Domain.Interfaces
{
    public interface IGenreRepository
    {
        Task AddAsync(Genre genre);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
    }
}
