using Xunit;
using Xunit.Abstractions;

namespace AlphabeticalTestOrderer.UnitTest;

// TestCaseOrdererAttribute(string ordererTypeName, string ordererAssemblyName)
//  - ordererTypeName : 네임스페이스명.클래스명(ITestCaseOrderer 인터페이스 상속 클래스)
//  - ordererAssemblyName : 어셈블리명
[TestCaseOrderer("AlphabeticalTestOrderer.UnitTest.AlphabeticalOrderer", "AlphabeticalTestOrderer.UnitTest")]
public class AlphabeticalTestOrdererSpec
{
    private ITestOutputHelper _output;

    public AlphabeticalTestOrdererSpec(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Test1()
    {
        _output.WriteLine("AlphabeticalTestOrdererSpec::Test1");
    }

    [Fact]
    public void Test2()
    {
        _output.WriteLine("AlphabeticalTestOrdererSpec::Test2");
    }

    [Fact]
    public void Test3()
    {
        _output.WriteLine("AlphabeticalTestOrdererSpec::Test3");
    }
}