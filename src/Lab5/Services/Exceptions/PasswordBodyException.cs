namespace Services.Exceptions;

public class PasswordBodyException : System.Exception
{
    public PasswordBodyException(string message)
        : base(message)
    {
    }

    public PasswordBodyException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public PasswordBodyException()
    {
    }
}