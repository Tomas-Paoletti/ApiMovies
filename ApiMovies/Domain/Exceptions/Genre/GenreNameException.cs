namespace ApiMovies.Domain.Exceptions.Genre
{
    public class GenreNameException :Exception
    {
        public GenreNameException(string message) : base( message)
        {
        }
    }
}
