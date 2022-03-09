# 단위 테스트 Fluent Assertion

```cs
using Xunit;
using FluentAssertions;

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
        //
        // Equal 메서드의 단점
        // public static void Equal<T>(T expected, T actual);
        //  - expected와 actual은 동일한 타입이다.
        //  - 타입이 같아서 순서가 올바르지 않아도 정상적으로 실행한다.
        Assert.Equal(7, actual);    // 순서가 올바름
        Assert.Equal(actual, 7);    // 순서가 올바르지 않음

        // FluentAssertions 패키지는 더 직관적으로 Assert 구문을 작성할 수 있다.
        actual.Should().Be(7);
    }
}
```
- `Assert.Equal(7, actual);` vs. `actual.Should().Be(7);` 오른쪽 코드가 더 직관적이다.
  - `Fluent Assertions` 패키지는 Assertion 구문을 더 직관적으로 구현할 수 있도록 제공한다.
  - Fluent Assertions 문서 : [링크](https://fluentassertions.com/introduction)
- `Fluent Assertions` 예제
  ```cs
  string actual = "ABCDEFGHI";

  actual
    .Should().StartWith("AB")
    .And.EndWith("HI")
    .And.Contain("EF")
    .And.HaveLength(9);
  ```