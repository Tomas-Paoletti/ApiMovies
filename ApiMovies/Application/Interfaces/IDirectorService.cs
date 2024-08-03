using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Interfaces
{
    public interface IDirectorService
    {
        Task<IEnumerable<Director>> GetAllAsync();
        Task<Director> GetByIdAsync(int id);
        Task AddAsync(Director director);
        Task UpdateAsync(Director director, int id);
        Task DeleteAsync(int id);
    }
}
