using System;
using Xunit;

namespace CalculatorLib.UnitTest;

public class CalculatorSpec
{
    [Fact]
    public void Test_succeeds_when_there_are_no_exceptions()
    {
        // 성공 : 예외가 없다.
    }

    [Fact]
    public void Test_fails_when_there_are_exceptions()
    {
        // 실패 : 예외가 있다.
        throw new Exception("예외가 발생할 때 단위 테스트는 실패한다.");
    }
}
