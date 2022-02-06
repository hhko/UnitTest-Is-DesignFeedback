using Xunit;
using System.Threading;

namespace CalculatorLib.UnitTest;

public class Parallel1Spec
{
    [Fact]
    public void Test11()
    {
        Thread.Sleep(3000);
    }

    [Fact]
    public void Test12()
    {
        Thread.Sleep(4000);
    }
}