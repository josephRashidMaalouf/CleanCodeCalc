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

    public double GetResult(double first, double second, OperationChar operation)
    {
        return _operationPicker[operation.Operation].Calculate(first, second);
    }
}