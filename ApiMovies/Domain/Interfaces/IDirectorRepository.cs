using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Domain.Interfaces
{
    public interface IDirectorRepository
    {
        Task AddAsync(Director director);
        Task<IEnumerable<Director>> GetAllAsync();
        Task<Director> GetByIdAsync(int id);
        Task UpdateAsync(Director director , int id);
        Task DeleteAsync(int id);
    }
}
