using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Utilities;

namespace CleanCodeCalc.Library.Tests.Utilities;

public class CalculatorTests
{
    [Theory]
    [InlineData("2+3*5", 17)]
    [InlineData("10+2*6", 22)]
    [InlineData("100*2+12", 212)]
    [InlineData("1+2+3", 6)]
    [InlineData("5+6/2", 8)]
    [InlineData("8-4-2", 2)]
    [InlineData("18/3/3", 2)]
    [InlineData("7+3*2-4", 9)]
    [InlineData("9*2+5-3", 20)]
    [InlineData("12+6/2*3", 21)]

    public void GetResult_ReturnsCorrectCalculationResult(string input, double expected)
    {
        //Arrange
        var calcInput = new CalculationInput(input);
        //Act
        var result = Calculator.Calculate(calcInput);
        //Assert
        Assert.Equal(expected, result);
    }
}