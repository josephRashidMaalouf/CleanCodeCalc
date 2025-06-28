using CleanCodeCalc.Library.Exceptions;

namespace CleanCodeCalc.Library.Models;

public record OperationChar
{
    public readonly bool IsOperationSet;
    public char Operation { get; set; }

    public OperationChar(char operation)
    {
        Operation = operation switch
        {
            '*' => '*',
            '/' => '/',
            '-' => '-',
            '+' => '+',
            _ => throw new InvalidOperationCharException()
        };
        IsOperationSet = true;
    }

    private OperationChar()
    {
        IsOperationSet = false;
    }

    public static bool TryParse(string? input, out OperationChar? result)
    {
        result = input switch
        {
            "*" => new OperationChar('*'),
            "/" => new OperationChar('/'),
            "-" => new OperationChar('-'),
            "+" => new OperationChar('+'),
            _ => new OperationChar()
        };

        if (!result.IsOperationSet)
        {
            result = null;
            return false;
        }

        return result.IsOperationSet;
    }
    public static bool TryParse(char? input, out OperationChar result)
    {
        result = input switch
        {
            '*' => new OperationChar('*'),
            '/' => new OperationChar('/'),
            '-' => new OperationChar('-'),
            '+' => new OperationChar('+'),
            _ => new OperationChar()
        };
        return result.IsOperationSet;
    }

    public override string ToString()
    {
        return Operation.ToString();
    }
}


