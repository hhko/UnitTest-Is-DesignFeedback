using Xunit;
using FluentAssertions;

namespace Helloworld.UnitTest;

public class GreetingSpec
{
    [Theory]
    [InlineData("Foo", "Hello Foo")]
    [InlineData("", "Hello ")]
    [InlineData(null, "Hello ")]
    public void Succeed(string input, string expected)
    {
        // Arrange
        Greeting sut = new Greeting();

        // Act
        string actual = sut.For(input);

        // Assert
        actual.Should().Be(expected);
    }
}