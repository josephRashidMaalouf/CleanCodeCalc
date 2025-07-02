using CleanCodeCalc.Console.Models;

namespace CleanCodeCalc.Console.Handlers;

public class BackspaceInputHandler : InputHandlerBase
{
    public override void Handle(InputData inputData)
    {
        if (inputData.UserInput.Key == ConsoleKey.Backspace && !string.IsNullOrWhiteSpace(inputData.CalculationInput))
        {
            var newCalcInput = new Stack<char>(inputData.CalculationInput);
            newCalcInput.Pop();
            inputData.CalculationInput = new string(newCalcInput.ToArray());
        }
        base.Handle(inputData);
    }
}