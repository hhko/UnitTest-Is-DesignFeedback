# 단위 테스트

## 목표
- 단위 테스트 프로젝트
  - `dotnet new xunit`
  - `dotnet test`
- 단위 테스트 구현
  - `Spec`
  - `[Fact]`
  - `void`
- 테스트 성공 & 실패
  - `성공` : 예외가 없을 때
  - `실패` : 예외가 있을 때

## 명령 요약
```shell
# 프로젝트 구성
dotnet new sln -n UnitTest
dotnet new xunit -o Calculator.UnitTest

# 솔루션 구성
dotnet sln add .\Calculator.UnitTest

dotnet build
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
    }
}
```
- 클래스 정의
  - 접미사 : `Spec`
  - 예
    ```cs
    public class CalculatorSpec
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

## 테스트 성공 & 실패
```cs
[Fact]
public void Success()
{
    // 테스트 성공 : 예외가 없을 떄
}

[Fact]
public void Failure()
{
    // 테스트 실패 : 예외가 있을 때
    throw new Exception("단위 테스트 실패는 예외다");
}
```
- 테스트 성공 : 예외가 없을 때
  ```cs
  [Fact]
  public void Success()
  {
      // 예외가 없을 때
  }
  ```
- 테스트 실패 : 예외가 있을 떄
  ```cs
  [Fact]
  public void Failure()
  {
      // 예외가 있을 때
      throw new Exception("단위 테스트 실패는 예외다");
  }
  ```
- 단위 테스트 실행 결과
  ```shell
  [xUnit.net 00:00:00.56]     Calculator.UnitTest.CalculatorSpec.Failure [FAIL]
    실패 Calculator.UnitTest.CalculatorSpec.Failure [8 ms]
    오류 메시지:
     System.Exception : 단위 테스트 실패는 예외다
    스택 추적:
       at Calculator.UnitTest.CalculatorSpec.Failure() in C:\Workspace\UnitTest-With\Part01\Ch01\Calculator.UnitTest\CalculatorSpec.cs:line 17

  실패!  - 실패:     1, 통과:     1, 건너뜀:     0, 전체:     2, 기간: 6 ms - Calculator.UnitTest.dll (net6.0)
  ```
  - 실패: 1
  - 통과: 1