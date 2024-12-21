namespace Services.Exceptions;

public class NameLengthException : Exception
{
    public NameLengthException(string message)
        : base(message)
    {
    }

    public NameLengthException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NameLengthException()
    {
    }
}