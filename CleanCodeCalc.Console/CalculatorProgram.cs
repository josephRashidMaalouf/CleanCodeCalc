using CleanCodeCalc.Console.Handlers;
using CleanCodeCalc.Console.Models;

namespace CleanCodeCalc.Console;

public class CalculatorProgram
{
    private readonly IInputHandler _handler;
    private readonly InputData _inputData;

    public CalculatorProgram(IInputHandler handler)
    {
        _handler = handler;
        _inputData = new InputData();
    }
    public void Start()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine(_inputData.Total);
            System.Console.WriteLine(_inputData.CalculationInput);
            _inputData.UserInput = System.Console.ReadKey();
            _handler.Handle(_inputData);

        }
    }
}