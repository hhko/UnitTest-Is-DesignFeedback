using Xunit;
using System.Threading;

namespace CalculatorLib.UnitTest;

public class Parallel1Spec
{
    [Fact]
    public void Test1()
    {
        Thread.Sleep(3000);
    }
}