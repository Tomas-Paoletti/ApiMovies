using ApiMovies.Domain.Interfaces;
using ApiMovies.Infraestructure.Data;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMovies.Domain.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieContext _context;

        public DirectorRepository(MovieContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Director director)
        {
            await  _context.Directors.AddAsync(director);

        }

        public async Task DeleteAsync(int id)
        {
             await _context.Directors.FindAsync(id);
         
        }

        public async Task<IEnumerable<Director>> GetAllAsync()
        {
            return await _context.Directors.ToListAsync();
            
        }

        public  async Task<Director> GetByIdAsync(int id)
        {
            var directorFind = await _context.Directors.FindAsync(id);

            if (directorFind == null)
            {
                return null;
            }
            return directorFind;
        }

        public async Task UpdateAsync(Director director, int id)
        {
             await  _context.Directors.FindAsync(id);
           
            
        }
    }
}
