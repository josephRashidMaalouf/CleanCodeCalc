// See https://aka.ms/new-console-template for more information

using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Utilities;


CalculatorProgram.Start();


static class CalculatorProgram
{
    static double Total = 0;
    public static void Start()
    {
        string calcInput = "";
        bool isOperationRequested = false;
        while (true)
        {
            Console.Clear();
            Console.WriteLine(Total);
            Console.WriteLine(calcInput);
            var input = Console.ReadKey();


            if (char.IsDigit(input.KeyChar))
            {
                calcInput += input.KeyChar;
                if (isOperationRequested)
                {
                    isOperationRequested = false;
                    Total = Calculator.Calculate(CalculationInput.Create(calcInput));
                }
            }

            if (OperationChar.TryCreate(input.KeyChar, out var operationChar))
            {
                isOperationRequested = true;
                if (char.IsDigit(calcInput[^1]))
                {
                    calcInput += input.KeyChar;
                    continue;
                }

                char[] newCalcInput = calcInput.ToCharArray();
                newCalcInput[^1] = input.KeyChar;
                calcInput = new string(newCalcInput);

            }

            if (input.KeyChar == '=' || input.Key == ConsoleKey.Enter)
            {
                Total = Calculator.Calculate(CalculationInput.Create(calcInput));
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                var newCalcInput = new Stack<char>(calcInput);
                newCalcInput.Pop();
                calcInput = new string(newCalcInput.ToArray());
            }

        }
    }
}


