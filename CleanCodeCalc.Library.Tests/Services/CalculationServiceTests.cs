using CleanCodeCalc.Library.Models;
using CleanCodeCalc.Library.Services;

namespace CleanCodeCalc.Library.Tests.Services;

public class CalculationServiceTests
{
    private readonly CalculationService _sut;

    public CalculationServiceTests()
    {
        _sut = new CalculationService();
    }

    [Theory]
    [InlineData("2+3*5", (double)17)]
    [InlineData("2+3*5*2", (double)32)]
    [InlineData("2+3*5+1", (double)18)]
    [InlineData("20/2-1", (double)9)]
    [InlineData("2+3*5*2/4-4", (double)5)]
    public void GetResult(string input, double expected)
    {
        //Arrange
        var calcInput = new CalculationInput(input);
        //Act
        var result = _sut.GetResult(calcInput);
        //Assert
        Assert.Equal(expected, result);
    }
}