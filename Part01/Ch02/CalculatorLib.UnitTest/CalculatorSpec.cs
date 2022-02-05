using System;
using Xunit;

namespace CalculatorLib.UnitTest;

public class CalculatorSpec
{
    [Fact]
    public void Test_succeeds_when_there_are_no_exceptions()
    {

    }

    [Fact]
    public void Test_fails_when_there_are_exceptions()
    {
        throw new Exception("예외가 발생할 때 단위 테스트는 실패한다.");
    }
}