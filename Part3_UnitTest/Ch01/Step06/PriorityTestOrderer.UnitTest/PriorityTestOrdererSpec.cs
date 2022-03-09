using Xunit;
using Xunit.Abstractions;

namespace PriorityTestOrderer.UnitTest;

// TestCaseOrdererAttribute(string ordererTypeName, string ordererAssemblyName)
//  - ordererTypeName : 네임스페이스명.클래스명(ITestCaseOrderer 인터페이스 상속 클래스)
//  - ordererAssemblyName : 어셈블리명
[TestCaseOrderer("PriorityTestOrderer.UnitTest.PriorityOrderer", "PriorityTestOrderer.UnitTest")]
public class PriorityTestOrdererSpec
{
    private ITestOutputHelper _output;

    public PriorityTestOrdererSpec(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact, TestPriority(5)]
    public void Test3()
    {
        _output.WriteLine("PriorityTestOrdererSpec::Test3, Priority 5");
    }

    [Fact, TestPriority(0)]
    public void Test2B()
    {
        _output.WriteLine("PriorityTestOrdererSpec::Test2B, Priority 0");
    }

    //
    // TestPriority가 없으면 0으로 처리한다.
    // 동일한 TestPriority일 때는 테스트 메서드명 기준으로 실행 순서를 정렬한다.
    //  예. Test2A, Test2B
    //
    [Fact]
    public void Test2A()
    {
        _output.WriteLine("PriorityTestOrdererSpec::Test2A, Priority -");
    }

    [Fact, TestPriority(-5)]
    public void Test1()
    {
        _output.WriteLine("PriorityTestOrdererSpec::Test1, Priority -5");
    }
}