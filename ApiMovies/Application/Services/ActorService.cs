using ApiMovies.Application.Interfaces;
using ApiMovies.Domain.Interfaces;
using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }

        public async Task CreateActor(Actor actor)
        {
            if (actor == null)
            {
                throw new ArgumentNullException(nameof(actor));
            }
            if (actor.Name == null || actor.BirthDate == null)
            {
                throw new ArgumentNullException(nameof(actor.Name));
            }
            await _actorRepository.AddAsync(actor);
        }

        public async Task DeleteActor(int id)
        {
            if (id == 0)
            {
                throw new System.ArgumentNullException(nameof(id));
            }
            await _actorRepository.DeleteAsync(id);
        }

        public Task<Actor> GetActorId(int id)
        {
            if (id == 0)
            {
                throw new System.ArgumentNullException(nameof(id));
            }
            var actor = _actorRepository.GetByIdAsync(id);

            if (actor == null)
            {
                throw new System.ArgumentNullException(nameof(actor));
            }
            return actor;
        }

        public Task<IEnumerable<Actor>> GetActors()
        {
           var actors = _actorRepository.GetAllAsync();
            if (actors == null)
            {
                throw new System.ArgumentNullException(nameof(actors));
            }
            return actors;
        }

        public async  Task UpdateActor(Actor actor, int id)
        {
           if (actor == null)
            {
                throw new System.ArgumentNullException(nameof(actor));
            }
            if (id == 0)
            {
                throw new System.ArgumentNullException(nameof(id));
            }
            await _actorRepository.UpdateAsync(actor, id);
        }
    }
}
