using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Strategies;

namespace CleanCodeCalc.Library.Utilities;

public static class Calculator
{
    private static readonly Dictionary<char, IOperationStrategy> OperationPicker = new Dictionary<char, IOperationStrategy>()
    {
        { '*', new Multiply() },
        { '-', new Subtract() },
        { '+', new Add() },
        { '/', new Divide() },
    };


    private static double GetResult(double first, double second, OperationChar operation)
    {
        return OperationPicker[operation.Operation].Calculate(first, second);
    }

    public static double Calculate(CalculationInput input)
    {
        List<string> postfix = PostfixConverter.Convert(input);
        var stack = new Stack<double>();

        foreach (var unit in postfix)
        {
            if (double.TryParse(unit, out double number))
            {
                stack.Push(number);
                continue;
            }

            if (!OperationChar.TryParse(unit, out OperationChar? operation) || operation is null)
            {
                throw new ArgumentException($"Found invalid char in the CalcInput: {unit}");
            }

            var second = stack.Pop();
            var first = stack.Pop();
            var result = GetResult(first, second, operation);
            stack.Push(result);
        }

        return stack.Pop();
    }

    
}