using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Interfaces
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetActors();
        public Task<Actor> GetActorId(int id);
        public Task CreateActor(Actor actor);
        public Task UpdateActor(Actor actor, int id );
        public Task DeleteActor(int id);
    }
}
