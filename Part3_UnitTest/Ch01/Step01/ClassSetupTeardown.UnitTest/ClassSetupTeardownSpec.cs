using System;
using Xunit;
using Xunit.Abstractions;

namespace ClassSetupTeardown.UnitTest;

public class ClassSetupTeardownSpec : IDisposable
{
    private ITestOutputHelper _output;

    public ClassSetupTeardownSpec(ITestOutputHelper output)
    {
        _output = output;
        _output.WriteLine("ClassSetupTeardownSpec::ClassSetupTeardownSpec 생성자");
    }

    [Fact]
    public void Test1()
    {
        _output.WriteLine("ClassSetupTeardownSpec::Test1 메서드");
    }

    [Fact]
    public void Test2()
    {
        _output.WriteLine("ClassSetupTeardownSpec::Test2 메서드");
    }

    public void Dispose()
    {
        _output.WriteLine("ClassSetupTeardownSpec::Dispose 메서드");
    }
}