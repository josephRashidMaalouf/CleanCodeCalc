namespace CleanCodeCalc.Library.Strategies;

public class Divide : IOperationStrategy
{
    public double Calculate(double first, double second)
    {
        return first / second;
    }
}