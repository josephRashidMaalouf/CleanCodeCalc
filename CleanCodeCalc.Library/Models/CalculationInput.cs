using System.Text;

namespace CleanCodeCalc.Library.Models;


public class CalculationInput
{
    public readonly bool IsInputSet;
    public string Input { get; private set; } = string.Empty;

    public CalculationInput(string input)
    {
        List<char> inputAsCharList = input.ToList();

        if (!ValidateInput(inputAsCharList))
        {
            throw new ArgumentException(
                "Invalid calculation input. A valid calculation input must consist of at least 3 characters, contain only digits and operators, start and end with a digit and contain at least one valid operator");
        }

        Input = input;
        IsInputSet = true;
    }

    private CalculationInput(string input, bool isValidInput)
    {
        if (!isValidInput)
        {
            IsInputSet = false;
            return;
        }
        Input = input;
        IsInputSet = true;
    }


    public static bool TryParse(string input, out CalculationInput? result)
    {
        result = new CalculationInput(input, ValidateInput(input.ToList()));

        if (!result.IsInputSet)
        {
            result = null;
            return false;
        }

        return result.IsInputSet;
    }

    private static bool ValidateInput(List<char> input)
    {
        //An operation should have at least three chars, for example: 1+1
        if (input.Count < 3)
        {
            return false;
        }
        //If any char in the string is not a digit nor an operation, the input is invalid
        if (!input.All(c => char.IsDigit(c) || OperationChar.TryParse(c, out _)))
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
        if (!input.Any(c => OperationChar.TryParse(c, out _)))
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