using CleanCodeCalc.Console.Models;
using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Utilities;

namespace CleanCodeCalc.Console.Handlers;

public class EqualityInputHandler : InputHandlerBase
{
    public override void Handle(InputData inputData)
    {
        if ((inputData.UserInput.KeyChar == '=' || inputData.UserInput.Key == ConsoleKey.Enter) && !string.IsNullOrWhiteSpace(inputData.CalculationInput))
        {
            inputData.Total = Calculator.Calculate(CalculationInput.Create(inputData.CalculationInput));
        }
        base.Handle(inputData);
    }
}