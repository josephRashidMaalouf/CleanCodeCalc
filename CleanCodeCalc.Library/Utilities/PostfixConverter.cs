using CleanCodeCalc.Library.Models;

namespace CleanCodeCalc.Library.Utilities;

public class PostfixConverter
{
    public static List<string> Convert(CalculationInput input)
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

            if (!stack.TryPeek(out var peekResult) || priority[unit] > priority[peekResult.ToString()])
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