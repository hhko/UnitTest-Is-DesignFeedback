using System;
using Xunit;
using FluentAssertions;

namespace ExampleProject.UnitTest;

public class CalculatorSpec
{
    [Theory]
    [InlineData(5, 5, 10)]
    public void Test_Add(int first, int second, int expected)
    {
        // Arrange
        Calculator sut = new Calculator();

        // Act
        int actual = sut.Add(first, second);

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 5, 0)]
    [InlineData(10, 5, 5)]      // Mutation Test
    public void Test_Subtract(int first, int second, int expected)
    {
        // Arrange
        Calculator sut = new Calculator();

        // Act
        int actual = sut.Subtract(first, second);

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    public void Test_Multiply(int first, int second, int expected)
    {
        // Arrange
        Calculator sut = new Calculator();

        // Act
        int actual = sut.Multiply(first, second);

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, 1, 1, 0)]
    public void Test_Divide(int first, int second, int expectedResult, int expectedRemainder)
    {
        // Arrange
        Calculator sut = new Calculator();

        // Act
        (int actualResult, int actualRemainder) = sut.Divide(first, second);

        // Assert
        actualResult.Should().Be(expectedResult);
        actualRemainder.Should().Be(expectedRemainder);
    }

    [Fact]
    public void Test_Divide_ByZero()
    {
        // Arrange
        Calculator sut = new Calculator();

        // Act
        var actual = () => sut.Divide(1, 0);

        // Assert
        actual.Should().Throw<DivideByZeroException>();
    }
}