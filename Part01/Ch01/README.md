# 단위 테스트

## 목표
- 단위 테스트 프로젝트 : `xunit`
- 단위 테스트 정의 : `Spec`, `[Fact]`
- 단위 테스트 구현 패턴 : `Arrange`, `Act`, `Assert`
- 단위 테스트 실행 : `dotnet test`

## 명령 요약
```shell
# 프로젝트 구성
dotnet new sln -n UnitTest3aPattern
dotnet new console -o CalculatorApp
dotnet new classlib -o CalculatorLib
dotnet new xunit -o CalculatorLib.UnitTest

# 프로젝트 추가
dotnet sln add .\CalculatorApp
dotnet sln add .\CalculatorLib
dotnet sln add .\CalculatorLib.UnitTest

# 솔루션 빌드
dotnet build
dotnet run --project .\CalculatorApp

# 솔로션 테스트 실행
dotnet test
dotnet test --no-build --no-restore
```

## 테스트 프로젝트
```
dotnet new xunit -n 프로젝트명 -o 폴더명
```
- 패키지
  - `xunit`
  - `xunit.runner.visualstudio`
  - `Microsoft.NET.Test.Sdk`

## 테스트 구현
```cs
using Xunit;

// Calculator 스펙
public class CalculatorSpec
{
    [Fact]
    public void Test()
    {
        // Arrange : 입력 확인
        Calculator sut = new Calculator();

        // Act : 실행
        int actual = sut.Add(1, 6);

        // Assert : 출력 확인
        Assert.Equal(7, actual);
    }
}
```
- 클래스 정의
  - `Spec`
  - 예
    ```cs
    ```
- 테스트 메서드 정의
  - 애트류뷰트 : `[Fact]`
  - void 출력 타입 : `void`
  - 예
    ```cs
    [Fact]
    public void Test()
    {

    }
    ```
- 테스트 메서드 구현
  - 예
    ```cs
    [Fact]
    public void Test()
    {
        // Arrange : 입력 확인

        // Act : 실행

        // Assert : 출력 확인
    }
    ```