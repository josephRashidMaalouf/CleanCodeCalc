using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Strategies;

namespace CleanCodeCalc.Library.Services;

public class CalculationService
{
    private readonly Dictionary<char, IOperationStrategy> _operationPicker;

    public CalculationService()
    {
        _operationPicker = new Dictionary<char, IOperationStrategy>()
        {
            { '*', new Multiply() },
            { '-', new Subtract() },
            { '+', new Add() },
            { '/', new Divide() },
        };
    }

    private double GetSimpleResult(double first, double second, OperationChar operation)
    {
        return _operationPicker[operation.Operation].Calculate(first, second);
    }

    public double GetResult(CalculationInput input)
    {
        double result = 0;
        //look for prioritized operations
        var factors = input.Input.Split('*');

        //if any, calculate values on each side
        if (factors.Any())
        {

        }

        //calculate the remaining operations in order
        //return result
        return 0;
    }
}