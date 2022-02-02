# 단위 테스트

## 목표
- 단위 테스트 프로젝트
  - `dotnet new xunit`
  - `dotnet test`
- 단위 테스트 구현
  - `Spec` : 테스트 클래스명
  - `[Fact]` : 테스트 메서드 애트리뷰트
  - `void` : 테스트 메서드 반환 타입
- 테스트 성공 & 실패
  - `성공` : 예외가 **없을** 때
  - `실패` : 예외가 **있을** 때

## 명령 요약
```shell
# 프로젝트 구성
dotnet new sln -n UnitTest
dotnet new xunit -o CalculatorLib.UnitTest

# 솔루션 구성
dotnet sln add .\CalculatorLib.UnitTest

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
- 단위 테스트 실행 결과
  ```shell
  # 테스트 실행
  dotnet test

  # 테스트 실행 결과
  [xUnit.net 00:00:00.85]     CalculatorLib.UnitTest.CalculatorSpec.Failure [FAIL]
    실패 CalculatorLib.UnitTest.CalculatorSpec.Failure [2 ms]
    오류 메시지:
     System.Exception : 단위 테스트 실패는 예외다
    스택 추적:
       at CalculatorLib.UnitTest.CalculatorSpec.Failure() in C:\Workspace\UnitTest-With\Part01\Ch01\CalculatorLib.UnitTest\CalculatorSpec.  cs:line 17

  실패!  - 실패:     1, 통과:     1, 건너뜀:     0, 전체:     2, 기간: 6 ms - CalculatorLib.UnitTest.dll (net6.0)
  ```
  - 실패: 1
  - 통과: 1