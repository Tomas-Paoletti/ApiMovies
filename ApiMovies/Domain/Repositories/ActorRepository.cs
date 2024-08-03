using ApiMovies.Domain.Interfaces;
using ApiMovies.Infraestructure.Data;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMovies.Domain.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly MovieContext _context;

        public ActorRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
            await  _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(int id)
        {
          Actor DeleteActor = await this.GetByIdAsync(id);


          _context.Actors.Remove(DeleteActor);
            await _context.SaveChangesAsync();
             
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
            
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
           return await _context.Actors.FindAsync(id);
           
        }

      

        public async Task UpdateAsync(Actor actor, int i)
        {
            var ActiorToUpdate = await this.GetByIdAsync(i);
            ActiorToUpdate.Name = actor.Name;
            ActiorToUpdate.BirthDate = actor.BirthDate;  
            await _context.SaveChangesAsync();
        }
    }
}
