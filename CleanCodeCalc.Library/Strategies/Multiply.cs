namespace CleanCodeCalc.Library.Strategies;

public class Multiply : IOperationStrategy
{
    public double Calculate(double first, double second)
    {
        return first * second;
    }
}