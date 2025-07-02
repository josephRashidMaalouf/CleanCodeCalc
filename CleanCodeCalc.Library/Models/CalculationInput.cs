using System.Text;

namespace CleanCodeCalc.Library.Models;


public class CalculationInput
{
    public string Input { get; private set; } 

    private CalculationInput(string input)
    {
        Input = input;
    }

    public static bool TryCreate(string input, out CalculationInput? result)
    {
        var validationResult = ValidateInput(input.ToList());

        if (!validationResult)
        {
            result = null;
            return false;
        }

        result = new CalculationInput(input);
        return true;
    }
    public static CalculationInput Create(string input)
    {
        List<char> inputAsCharList = input.ToList();

        if (!ValidateInput(inputAsCharList))
        {
            throw new ArgumentException(
                "Invalid calculation input. A valid calculation input must consist of at least 3 characters, contain only digits and operators, start and end with a digit and contain at least one valid operator");
        }

        return new CalculationInput(input);
    }

    private static bool ValidateInput(List<char> input)
    {
        //An operation should have at least three chars, for example: 1+1
        if (input.Count < 3)
        {
            return false;
        }
        //If any char in the string is not a digit nor an operation, the input is invalid
        if (!input.All(c => char.IsDigit(c) || OperationChar.TryCreate(c, out _)))
        {
            return false;
        }
        //First char should be a digit
        if (!char.IsDigit(input.First()))
        {
            return false;
        }
        //Last char should be a digit
        if (!char.IsDigit(input.Last()))
        {
            return false;
        }
        //Input should contain at least one operator
        if (!input.Any(c => OperationChar.TryCreate(c, out _)))
        {
            return false;
        }

        return true;
    }
    public override string ToString()
    {
        return Input.ToString();
    }

    public List<string> ToList()
    {
        List<string> output = new();
        var str = string.Empty;
        foreach (char c in Input)
        {
            if (char.IsDigit(c))
            {
                str += c;
                continue;
            }
            output.Add(str);
            str = string.Empty;
            output.Add(c.ToString());
        }

        if (!string.IsNullOrWhiteSpace(str))
        {
            output.Add(str);
        }
        return output;
    }
}