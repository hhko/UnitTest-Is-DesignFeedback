using Xunit;
using FluentAssertions;

namespace Helloworld.UnitTest;

public class UnitTestSpec
{
    [Fact]
    public void Test()
    {
        // Assert

        // Act
        string actual = Program.CreateGreetingMessage("Foo");

        // Assert
        actual.Should().Be("Hi Foo");
    }
}