using ApiMovies.Application.Interfaces;
using ApiMovies.Application.Utility.Interfaces;
using ApiMovies.Domain.Interfaces;

using ApiMovies.Infraestructure.Data.Dtos;
using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMovieValidationService movieValidationService;

        public MovieService(IMovieRepository movieRepository, IMovieValidationService movieValidationService)
        {
            this.movieRepository = movieRepository;
            this.movieValidationService = movieValidationService;
        }

        public async Task<Movie> AddAsync(CreateMovieDto createMovieDto)
        {
            if (createMovieDto == null)
                throw new ArgumentNullException(nameof(createMovieDto));

            if (createMovieDto.DirectorId == 0)
                throw new ArgumentException("DirectorId cannot be 0.", nameof(createMovieDto.DirectorId));

            var genres = createMovieDto.Genresids != null
                ? await movieValidationService.GetValidGenresAsync(createMovieDto.Genresids)
                : new List<MovieGenre>();

            var actors = createMovieDto.MovieActorsIds != null
                ? await movieValidationService.GetValidActorsAsync(createMovieDto.MovieActorsIds)
                : new List<MovieActor>();

            var movie = new Movie
            {
                Title = createMovieDto.Title,
                ReleaseDate = createMovieDto.ReleaseDate,
                Budget = createMovieDto.Budget ?? 0,
                Revenue = createMovieDto.Revenue ?? 0,
                Runtime = createMovieDto.Runtime,
                VoteAverage = createMovieDto.VoteAverage ?? 0,
                DirectorId = createMovieDto.DirectorId,
                MovieGenres = genres,
                MovieActors = actors
            };

            await movieRepository.AddAsync(movie);

            return movie;
        }
    }
}
