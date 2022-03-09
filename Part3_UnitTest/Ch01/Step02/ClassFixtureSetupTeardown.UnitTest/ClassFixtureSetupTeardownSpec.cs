using System;
using Xunit;
using Xunit.Abstractions;

namespace ClassFixtureSetupTeardown.UnitTest;

public class ClassFixtureSetupTeardown : IDisposable, IClassFixture<ClassFixture>
{
    private ITestOutputHelper _output;
    private ClassFixture _fixture;

    public ClassFixtureSetupTeardown(ITestOutputHelper output, ClassFixture fixture)
    {
        _output = output;
        _fixture = fixture;

        _output.WriteLine("ClassFixtureSetupTeardown::ClassFixtureSetupTeardown 생성자");
    }

    [Fact]
    public void Test1()
    {
        _output.WriteLine("ClassFixtureSetupTeardown::Test1 메서드");
    }

    [Fact]
    public void Test2()
    {
        _output.WriteLine("ClassFixtureSetupTeardown::Test2 메서드");
    }

    public void Dispose()
    {
        _output.WriteLine("ClassFixtureSetupTeardown::Dispose 메서드");
    }
}

