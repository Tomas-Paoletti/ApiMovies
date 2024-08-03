using ApiMovies.Application.Interfaces;
using ApiMovies.Domain.Exceptions.Genre;
using ApiMovies.Domain.Interfaces;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace ApiMovies.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task CreateGenreAsync(Genre genre)
        {
            Console.WriteLine("Creating genre");
            if(genre == null)
            {
                throw new GenreNotFountException("Object Genre is Null");
            }
            if (genre.Name.IsNullOrEmpty())
            {
                Console.WriteLine("Genre name is null or empty");
                throw new  GenreNameException("Genre name is null or empty");
            }

         
             await _genreRepository.AddAsync(genre);  
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            if(!genres.Any())
            {
                throw new ArgumentNullException("No genres found");
            }
           return genres;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new IdGenreInvalidException("Genre ID invalido ");
            }
            var genre = await _genreRepository.GetByIdAsync(id);
            if(genre == null)
            {
                throw new GenreNotFountException("Genre not found");
            }

            Console.WriteLine("Getting genre by id"+ id);
            return genre;
        }
        public async Task UpdateGenreAsync(Genre genre)
        {
            if(genre == null)
            {
                throw new GenreNotFountException("Object Genre is Null");
            }
            if(genre.Name.IsNullOrEmpty())
            {
                throw new GenreNameException("Genre name is null or empty");
            }
             await _genreRepository.UpdateGenreAsync(genre);
        }
        public async Task DeleteGenreAsync(int id)
        {
            if(id <= 0)
            {
                throw new IdGenreInvalidException("Genre ID invalido");
            }
            await _genreRepository.DeleteGenreAsync(id);
        }
    }
}
