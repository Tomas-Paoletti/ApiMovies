namespace ApiMovies.Domain.Exceptions.Genre
{
    public class GenreNotFountException : Exception
    {
        public GenreNotFountException(string message) : base(message)
        {
        }
    }
}
