# 단위 테스트 구성

## 프로젝트 구성
```shell
# 프로젝트 구성
dotnet new sln -n UnitTestStructure
dotnet new xunit -o CalculatorLib.UnitTest  # 단위 테스트 프로젝트

# 솔루션 구성
dotnet sln add .\CalculatorLib.UnitTest

# 솔루션 빌드
dotnet build
```
- `xunit` 템플릿으로 단위 테스트 프로젝트를 생성한다.
  - 단위 테스트 프로젝트명
    - `.UnitTest` 접미사를 사용한다.
  - 단위 테스트 필수 패키지 : `xunit` 템플릿이 자동으로 추가한다.
    - `Microsoft.NET.Test.Sdk`
    - `xunit`
    - `xunit.runner.visualstudio`

## 단위 테스트 구현
```cs
// Spec 접미사
public class CalculatorSpec
{
    [Fact]
    public void Success()
    {

    }
}
```
- 단위 테스트 클래스명
  - `.Spec` 접미사를 사용한다.
- 단위 테스트 메서드 지정
  - `[Fact]` 애트리뷰트를 추가한다.

## 단위 테스트 실행
```shell
dotnet test
dotnet test --no-build
dotnet test --logger "console;verbosity=detailed"
```
