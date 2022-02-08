using Xunit;
using FluentAssertions;

namespace ClassLibrary1.UnitTest;

public class Class1Spec
{
    [Fact]
    public void Test1()
    {
        Class1 sut = new Class1();

        int actual = sut.Method();

        actual.Should().Be(2022);
    }
}