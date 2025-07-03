using CleanCodeCalc.Console.Models;
using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Utilities;

namespace CleanCodeCalc.Console.Handlers;

public class BackspaceInputHandler : InputHandlerBase
{
    public override void Handle(InputData inputData)
    {
        if (inputData.UserInput.Key == ConsoleKey.Backspace && !string.IsNullOrWhiteSpace(inputData.CalculationInput))
        {
            var newCalcInput = new Stack<char>(inputData.CalculationInput);
            var deleted = newCalcInput.Pop();

            inputData.CalculationInput = new string(newCalcInput.Reverse().ToArray());

            if (CalculationInput.TryCreate(inputData.CalculationInput, out var calcInput) && calcInput is not null)
            {
                inputData.Total = Calculator.Calculate(calcInput);
            }

            if (inputData.CalculationInput.Length == 1)
            {
                inputData.Total = double.Parse(inputData.CalculationInput);
            }

            if (inputData.CalculationInput.Length == 0)
            {
                inputData.Total = 0;
            }
        }
        base.Handle(inputData);
    }
}