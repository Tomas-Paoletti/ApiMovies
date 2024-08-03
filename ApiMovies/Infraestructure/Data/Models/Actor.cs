namespace ApiMovies.Infraestructure.Data.Models
{
  
        public class Actor
        {
            public int ActorId { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }

        public ICollection<MovieActor>? MovieActors { get; set; } = new List<MovieActor>();

    }


}
