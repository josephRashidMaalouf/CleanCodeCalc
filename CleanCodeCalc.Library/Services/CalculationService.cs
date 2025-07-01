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
        List<string> postfix = GetPostFix(input);
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
            var result = GetSimpleResult(first, second, operation);
            stack.Push(result);
        }

        return stack.Pop();
    }

    private List<string> GetPostFix(CalculationInput input)
    {
        var output = new List<string>();
        var stack = new Stack<char>();
        var priority = new Dictionary<string, int>()
        {
            { "*", 2 },
            { "/", 2 },
            { "+", 1 },
            { "-", 1 },
        };

        foreach (var unit in input.ToList())
        {
            if (double.TryParse(unit, out _))
            {
                output.Add(unit);
                continue;
            }

            if(!stack.TryPeek(out var peekResult) || priority[unit] > priority[peekResult.ToString()])
            {
                stack.Push(char.Parse(unit));
                continue;
            }

            var popped = stack.Pop();
            output.Add(popped.ToString());
            stack.Push(char.Parse(unit));


        }

        output.AddRange(stack.Select(x => x.ToString()));

        return output;
    }
}