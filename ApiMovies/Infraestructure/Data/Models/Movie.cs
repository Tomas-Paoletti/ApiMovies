namespace ApiMovies.Infraestructure.Data.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
        public int Runtime { get; set; }
        public double VoteAverage { get; set; }
        public int DirectorId { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();


    }
}
