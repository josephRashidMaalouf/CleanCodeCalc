namespace CleanCodeCalc.Library.Strategies;

public class Add : IOperationStrategy
{
    public double Calculate(double first, double second)
    {
        return first + second;
    }
}