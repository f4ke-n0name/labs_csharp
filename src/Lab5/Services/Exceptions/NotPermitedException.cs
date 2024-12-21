namespace Services.Exceptions;

public class NotPermitedException : Exception
{
    public NotPermitedException(string message)
        : base(message)
    {
    }

    public NotPermitedException()
    {
    }

    public NotPermitedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}