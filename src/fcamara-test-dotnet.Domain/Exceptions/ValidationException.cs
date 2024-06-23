
namespace fcamara_test_dotnet.Domain.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}