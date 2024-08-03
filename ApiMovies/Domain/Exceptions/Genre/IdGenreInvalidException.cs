namespace ApiMovies.Domain.Exceptions.Genre
{
    public class IdGenreInvalidException : Exception
    {
        public IdGenreInvalidException(string message) : base(message)
        {
        }
    }
}
