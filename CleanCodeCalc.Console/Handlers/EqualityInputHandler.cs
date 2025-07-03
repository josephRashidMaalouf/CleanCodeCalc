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
            if (CalculationInput.TryCreate(inputData.CalculationInput, out var calcInput) && calcInput is not null)
            {
                inputData.Total = Calculator.Calculate(calcInput);
                inputData.CalculationInput = string.Empty;
            }
        }
        base.Handle(inputData);
    }
}