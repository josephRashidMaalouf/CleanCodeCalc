using CleanCodeCalc.Library.Models;

namespace CleanCodeCalc.Library.Tests.Models;

public class CalculationInputTests
{

    [Theory]
    [InlineData("1+1")]
    [InlineData("1*1")]
    [InlineData("1/1")]
    [InlineData("1-1")]
    [InlineData("12+1")]
    [InlineData("1+112")]
    [InlineData("112321+112")]
    [InlineData("1+1-12*5433")]
    [InlineData("1+112/2/2-409*3")]
    public void Parse_WithValidInput_InstantiatesWithInputSet(string input)
    {
        //Act
        var result = CalculationInput.Create(input);

        //Assert
        Assert.IsType<CalculationInput>(result);
        Assert.Equal(input, result.Input);
    }

    [Theory]
    [InlineData("1+1")]
    [InlineData("1*1")]
    [InlineData("1/1")]
    [InlineData("1-1")]
    [InlineData("12+1")]
    [InlineData("1+112")]
    [InlineData("112321+112")]
    [InlineData("1+1-12*5433")]
    [InlineData("1+112/2/2-409*3")]
    public void TryParse_WithValidInput_ReturnsTrueWithCalculationObjectOut_InputSet(string input)
    {
        //Act
        var result = CalculationInput.TryCreate(input, out var obj);

        //Assert
        Assert.True(result);

        Assert.IsType<CalculationInput>(obj);
        Assert.Equal(input, obj.Input);
    }

    [Theory]
    [InlineData("+1")]
    [InlineData("1*1-")]
    [InlineData("1/1d")]
    [InlineData("-1")]
    [InlineData("a12+1")]
    [InlineData("1112")]
    [InlineData("1sdf12321+11%&/2")]
    [InlineData("")]
    public void Parse_WithInValidInput_ThrowsArgumentException(string input)
    {
        //Act and Assert
        Assert.Throws<ArgumentException>(() => CalculationInput.Create(input));
    }

    [Theory]
    [InlineData("+1")]
    [InlineData("1*1-")]
    [InlineData("1/1d")]
    [InlineData("-1")]
    [InlineData("a12+1")]
    [InlineData("1112")]
    [InlineData("1sdf12321+11%&/2")]
    [InlineData("")]
    public void TryParse_WithInValidInput_ReturnsFalseWithNullObjectOut(string input)
    {
        //Act
        var result = CalculationInput.TryCreate(input, out var obj);

        //Assert
        Assert.False(result);

        Assert.Null(obj);
    }
    [Fact]
    public void ToList_ReturnsCorrectList()
    {
        //Arrange
        var sut = CalculationInput.Create("1+23-4325*2/90");
        var expected = new List<string>()
        {
            "1", "+", "23", "-", "4325", "*", "2", "/", "90"
        };

        //Act
        var result = sut.ToList();

        //Assert

        for(int i = 0; i < result.Count; i ++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}