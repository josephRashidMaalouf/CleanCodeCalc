// See https://aka.ms/new-console-template for more information

using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Services;

Console.WriteLine("Hello, World!");

var cs = new CalculationService();

LineReader.ReadLines(cs);

static class LineReader
{
    public static void ReadLines(CalculationService cs)
    {
        double total = 0;
        string output = "";

        if (total == 0)
        {
            bool isFirstNum = false;
            while (!isFirstNum)
            {
                isFirstNum = double.TryParse(Console.ReadLine(), out total);
            }
            output += $"{total} ";
        }
        Console.Clear();
        Console.Write(output);
        bool isOperationValid = false;
        OperationChar? operation = null;
        while (!isOperationValid)
        {
            isOperationValid = OperationChar.TryParse(Console.ReadLine(), out operation);
        }

        output += $"{operation} ";
        Console.Clear();
        Console.Write(output);
        bool isSecondNum = false;
        double second = 0;
        while (!isSecondNum)
        {
            isSecondNum = double.TryParse(Console.ReadLine(), out second);
        }

        output += $"{second} = ";
        Console.Clear();
        Console.Write(output);
        var result = cs.GetResult(total, second, operation!);
        output += $"{result}";
        Console.Clear();
        Console.Write(output);
    }
}