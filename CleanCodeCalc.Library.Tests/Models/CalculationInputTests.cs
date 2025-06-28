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
    public void NewCalculationInput_WithValidInput_InstantiatesWithInputSet(string input)
    {
        //Act
        var result = new CalculationInput(input);

        //Assert
        Assert.IsType<CalculationInput>(result);
        Assert.Equal(input, result.Input);
        Assert.True(result.IsInputSet);
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
        var result = CalculationInput.TryParse(input, out var obj);

        //Assert
        Assert.True(result);

        Assert.IsType<CalculationInput>(obj);
        Assert.Equal(input, obj.Input);
        Assert.True(obj.IsInputSet);
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
    public void NewCalculationInput_WithInValidInput_ThrowsArgumentException(string input)
    {
        //Act and Assert
        Assert.Throws<ArgumentException>(() => new CalculationInput(input));
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
        var result = CalculationInput.TryParse(input, out var obj);

        //Assert
        Assert.False(result);

        Assert.Null(obj);
    }
}