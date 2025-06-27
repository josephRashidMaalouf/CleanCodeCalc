namespace CleanCodeCalc.Library.Strategies;

public class Subtract : IOperationStrategy
{
    public double Calculate(double first, double second)
    {
        return first - second;
    }
}