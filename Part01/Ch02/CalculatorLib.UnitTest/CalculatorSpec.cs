using System;
using System.Threading;
using Xunit;

namespace CalculatorLib.UnitTest;

public class CalculatorSpec
{
    [Fact]
    public void Pass()
    {

    }

    [Fact]
    public void Failure()
    {
        throw new Exception("단위 테스트 실패는 예외다");
    }
}