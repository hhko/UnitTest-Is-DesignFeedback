using Xunit;

namespace CalculatorLib.UnitTest;

public class CalculatorSpec
{
    [Fact]
    public void Success()
    {
        int x = 1;
        int y = 6;

        Assert.Equal(7, x + y);
    }
}