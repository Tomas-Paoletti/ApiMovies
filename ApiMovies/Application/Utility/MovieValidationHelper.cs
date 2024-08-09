using ApiMovies.Application.Interfaces;
using ApiMovies.Application.Utility.Interfaces;
using ApiMovies.Domain.Interfaces;

using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Services
{
    public class MovieValidationService : IMovieValidationService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IActorRepository actorRepository;

        public MovieValidationService(IGenreRepository genreRepository, IActorRepository actorRepository)
        {
            this.genreRepository = genreRepository;
            this.actorRepository = actorRepository;
        }

        public async Task<List<MovieGenre>> GetValidGenresAsync(IEnumerable<int> genreIds)
        {
            var genres = new List<MovieGenre>();

            foreach (var genreId in genreIds)
            {
                var genre = await genreRepository.GetByIdAsync(genreId);
                if (genre == null)
                    throw new ArgumentException($"Genre with ID {genreId} not found.", nameof(genreIds));

                genres.Add(new MovieGenre { GenreId = genreId });
            }

            return genres;
        }

        public async Task<List<MovieActor>> GetValidActorsAsync(IEnumerable<int> actorIds)
        {
            var actors = new List<MovieActor>();

            foreach (var actorId in actorIds)
            {
                var actor = await actorRepository.GetByIdAsync(actorId);
                if (actor == null)
                    throw new ArgumentException($"Actor with ID {actorId} not found.", nameof(actorIds));

                actors.Add(new MovieActor { ActorId = actorId });
            }

            return actors;
        }
    }
}
