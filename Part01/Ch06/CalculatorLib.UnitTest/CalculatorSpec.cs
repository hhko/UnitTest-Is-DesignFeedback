using Xunit;
using Xunit.Abstractions;

namespace CalculatorLib.UnitTest;

public class CalculatorSpec
{
    // 단위 테스트 출력 인터페이스
    private readonly ITestOutputHelper _output;

    // xUnit이 ITestOutputHelper을 생성자에게 자동으로 주입(전달)한다.
    public CalculatorSpec(ITestOutputHelper output)
    {
        _output = output;
        _output.WriteLine($"Constructor");
    }

    [Fact]
    public void Test1()
    {
        _output.WriteLine($"Test1");
    }

    [Fact]
    public void Test2()
    {
        _output.WriteLine($"Test2");
    }
}