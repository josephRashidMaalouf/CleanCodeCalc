using CleanCodeCalc.Library.Exceptions;

namespace CleanCodeCalc.Library.Models;

public record OperationChar
{
    public char Operation { get; private set; }

    private OperationChar(char operation)
    {
        Operation = operation;
    }
    private OperationChar(string operation)
    {
        Operation = char.Parse(operation);
    }

    public static OperationChar Create(char operation)
    {
        var isValid = Validate(operation);
        if (!isValid)
        {
            throw new InvalidOperationCharException();
        }

        return new OperationChar(operation);
    }
    public static OperationChar Create(string operation)
    {
        var isValid = Validate(operation);
        if (!isValid)
        {
            throw new InvalidOperationCharException();
        }

        return new OperationChar(char.Parse(operation));
    }

    public static bool TryCreate(string input, out OperationChar? result)
    {
        var isValid = Validate(input);
        result = isValid ? new OperationChar(input) : null;

        return isValid;
    }
    public static bool TryCreate(char input, out OperationChar? result)
    {
        var isValid = Validate(input);
        result = isValid ? new OperationChar(input) : null;

        return isValid;
    }

    private static bool Validate(char input)
    {
        return input switch
        {
            '*' => true,
            '/' => true,
            '-' => true,
            '+' => true,
            _ => false
        };
    }
    private static bool Validate(string input)
    {
        return input switch
        {
            "*" => true,
            "/" => true,
            "-" => true,
            "+" => true,
            _ => false
        };
    }

    public override string ToString()
    {
        return Operation.ToString();
    }
}


