using CleanCodeCalc.Console.Models;
using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Utilities;

namespace CleanCodeCalc.Console.Handlers;

public class DigitInputHandler : InputHandlerBase
{
    public override void Handle(InputData inputData)
    {
        if (char.IsDigit(inputData.UserInput.KeyChar))
        {
            inputData.CalculationInput += inputData.UserInput.KeyChar;
            if (inputData.IsOperationRequested)
            {
                inputData.IsOperationRequested = false;
                inputData.Total = Calculator.Calculate(CalculationInput.Create(inputData.CalculationInput));
            }
        }
        base.Handle(inputData);
    }
}