using Xunit;
using FluentAssertions;

namespace CalculatorLib.UnitTest;

// Calculator 스펙
public class CalculatorSpec
{
    [Fact]
    public void Test()
    {
        // Arrange : 입력 준비
        Calculator sut = new Calculator();

        // Act : 실행
        int actual = sut.Add(1, 6);

        // Assert : 출력 확인
        //
        // Equal 메서드의 단점
        // public static void Equal<T>(T expected, T actual);
        //  - expected와 actual은 동일한 타입이다.
        //  - 타입이 같아서 순서가 올바르지 않아도 정상적으로 실행한다.
        Assert.Equal(7, actual);    // 순서가 올바름
        Assert.Equal(actual, 7);    // 순서가 올바르지 않음

        // FluentAssertions 패키지는 더 직관적으로 Assert 구문을 작성할 수 있다.
        actual.Should().Be(7);
    }
}