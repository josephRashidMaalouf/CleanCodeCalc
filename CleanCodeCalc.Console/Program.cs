using CleanCodeCalc.Console;
using CleanCodeCalc.Console.Builders;
using CleanCodeCalc.Console.Handlers;


var builder = new CalculatorAppBuilder();

builder
    .AddHandler(new BackspaceInputHandler())
    .AddHandler(new DigitInputHandler())
    .AddHandler(new OperationInputHandler())
    .AddHandler(new EqualityInputHandler());

var app = builder.Build();

app.Start();