using CleanCodeCalc.Console.Models;
using CleanCodeCalc.Library.Models;

namespace CleanCodeCalc.Console.Handlers;

public class OperationInputHandler : InputHandlerBase
{
    public override void Handle(InputData inputData)
    {
        if (OperationChar.TryCreate(inputData.UserInput.KeyChar, out _) && !string.IsNullOrWhiteSpace(inputData.CalculationInput))
        {
            if (char.IsDigit(inputData.CalculationInput[^1]))
            {
                inputData.CalculationInput += inputData.UserInput.KeyChar;
            }
            else
            {
                char[] newCalcInput = inputData.CalculationInput.ToCharArray();
                newCalcInput[^1] = inputData.UserInput.KeyChar;
                inputData.CalculationInput = new string(newCalcInput);
            }
        }
        base.Handle(inputData);
    }
}