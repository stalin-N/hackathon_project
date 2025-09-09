namespace MarstonX.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Validation failed") { }
    public ValidationException(string message) : base(message) { }
}