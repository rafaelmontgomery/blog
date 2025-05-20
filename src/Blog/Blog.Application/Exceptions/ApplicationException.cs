namespace Blog.Application.Exceptions;
public class BlogApplicationException : Exception
{
    public BlogApplicationException() { }

    public BlogApplicationException(string message)
        : base(message) { }

    public BlogApplicationException(string message, Exception innerException)
        : base(message, innerException) { }
}
