using Xunit;

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
        Assert.Equal(7, actual);
    }
}