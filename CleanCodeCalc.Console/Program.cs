using CleanCodeCalc.Console;
using CleanCodeCalc.Console.Handlers;

IInputHandler inputHandler = new BackspaceInputHandler();

    inputHandler
    .SetNext(new DigitInputHandler())
    .SetNext(new OperationInputHandler())
    .SetNext(new EqualityInputHandler());

new CalculatorProgram(inputHandler).Start();