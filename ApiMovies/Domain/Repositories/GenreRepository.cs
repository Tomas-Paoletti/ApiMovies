using ApiMovies.Domain.Interfaces;
using ApiMovies.Infraestructure.Data;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ApiMovies.Domain.Repositories
{
    public class GenreRepository : IGenreRepository 
    {
        private readonly MovieContext _context;

        public GenreRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Genre genre)
        {
           await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
           
        }

        public async  Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            Debug.WriteLine("Getting genre by id"+ id);
          
            var genreFind = await _context.Genres.FindAsync(id);
           
           return genreFind;
        }
        public async Task UpdateGenreAsync(Genre genre)
        {
             _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        
        }
        public async Task DeleteGenreAsync(int id)
        {
            Genre genre = await _context.Genres.FindAsync(id);
       
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
       
        }


        
    }
}
