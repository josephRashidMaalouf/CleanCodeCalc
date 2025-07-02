namespace CleanCodeCalc.Console.Models;

public class InputData
{
    public double Total { get; set; } = 0;
    public string CalculationInput { get; set; } = string.Empty;
    public ConsoleKeyInfo UserInput { get; set; } = new ConsoleKeyInfo();
    public bool IsOperationRequested { get; set; } = false;
}