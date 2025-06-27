namespace CleanCodeCalc.Library.Exceptions;

public class InvalidOperationCharException : Exception
{
    public override string Message { get; } = "Invalid operation char. Valid operation chars: +, -, *, /";
}