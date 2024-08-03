using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Domain.Interfaces
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task UpdateAsync(Actor actor, int id);
        Task DeleteAsync( int id);
    }
}
