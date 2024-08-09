using ApiMovies.Domain.Interfaces;
using ApiMovies.Infraestructure.Data;
using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Domain.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }
        public async  Task<Movie> AddAsync(Movie movie)
        {
           _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
