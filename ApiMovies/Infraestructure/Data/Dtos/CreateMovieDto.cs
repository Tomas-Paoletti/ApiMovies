using ApiMovies.Infraestructure.Data.Models;

namespace ApiMovies.Infraestructure.Data.Dtos

{
    public class CreateMovieDto
    {
      
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public int Runtime { get; set; }
        public double ?VoteAverage { get; set; }
        public int DirectorId { get; set; }

        public ICollection<int>? Genresids { get; set; } = new List<int>();
        public ICollection<int>? MovieActorsIds { get; set; } = new List<int>();
    }
}
