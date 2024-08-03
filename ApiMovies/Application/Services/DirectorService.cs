using ApiMovies.Application.Interfaces;
using ApiMovies.Domain.Interfaces;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovies.Application.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task AddAsync(Director director)
        {
            if (director == null)
            {
                throw new ArgumentNullException(nameof(director));
            }
            if (director.Name.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(director.Name));
            }

            await _directorRepository.AddAsync(director);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            await _directorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Director>> GetAllAsync()
        {
            var directors = await _directorRepository.GetAllAsync();

            if (!directors.Any())
            {
                throw new InvalidOperationException("No directors found");
            }
            return directors;
        }

        public async Task<Director> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var director = await _directorRepository.GetByIdAsync(id);
            return director;
        }

        public async Task UpdateAsync(Director director, int id)
        {
            if (director == null)
            {
                throw new ArgumentNullException(nameof(director));
            }
            await _directorRepository.UpdateAsync(director, id);
        }
    }
}
