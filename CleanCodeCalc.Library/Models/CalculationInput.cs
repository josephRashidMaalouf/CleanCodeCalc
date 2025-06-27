namespace CleanCodeCalc.Library.Models;


public class CalculationInput
{
    public readonly bool IsOperationSet;
    public string? Input { get; private set; }

    public CalculationInput(string input)
    {
        List<char> inputAsCharList = input.ToList();

        if (!ValidateInput(inputAsCharList))
        {
            throw new ArgumentException(
                "Invalid calculation input. A valid calculation input must consist of at least 3 characters, contain only digits and operators, start and end with a digit and contain at least one valid operator");
        }

        Input = input;
        IsOperationSet = true;
    }

    private CalculationInput(string input, bool isValidInput)
    {
        if (!isValidInput)
        {
            IsOperationSet = false;
            return;
        }
        Input = input;
        IsOperationSet = true;
    }


    public static bool TryParse(string input, out CalculationInput result)
    {
        result = new CalculationInput(input, ValidateInput(input.ToList()));
        return result.IsOperationSet;
    }

    private static bool ValidateInput(List<char> input)
    {
        //An operation should have at least three chars, for example: 1+1
        if (input.Count < 3)
        {
            return false;
        }
        //If any char in the string is not a digit nor an operation, the input is invalid
        if (input.Any(c => !char.IsDigit(c)) && input.Any(c => !OperationChar.TryParse(c, out _)))
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
        if (input.Any(c => OperationChar.TryParse(c, out _)))
        {
            return false;
        }

        return true;
    }
    public override string ToString()
    {
        return Input.ToString();
    }
}