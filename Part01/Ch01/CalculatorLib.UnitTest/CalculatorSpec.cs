using System;
using Xunit;

namespace CalculatorLib.UnitTest;

public class CalculatorSpec
{
    [Fact]
    public void Success()
    {

    }

    [Fact]
    public void Failure()
    {
        throw new Exception("단위 테스트 실패는 예외다");
    }
}