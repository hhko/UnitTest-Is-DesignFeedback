# Specflow 템플릿 설치

## 템플릿 생성
```shell
#
# Specflow 템플릿 Online 검색
#
dotnet new --search specflow

#
# Specflow 프로젝트 템플릿 설치
#
dotnet new -i SpecFlow.Templates.DotNet
#  다음 템플릿 패키지가 설치됩니다.
#     SpecFlow.Templates.DotNet
#
#  성공:SpecFlow.Templates.DotNet::3.9.52이(가) 다음 템플릿을 설치했습니다.
#  템플릿 이름                            약식 이름                  언어    태그
#  --------------------------------  ---------------------  ----  ---------------------------
#  SpecFlow Configuration JSON File  specflow-json          [C#]  SpecFlow/Configuration/JSON
#  SpecFlow Feature File             specflow-feature       [C#]  SpecFlow/Feature
#  SpecFlow Plus Profile             specflow-plus-profile  [C#]  SpecFlow Plus/Profile
#  SpecFlow Project Template         specflowproject        [C#]  SpecFlow/Project
dotnet new -l

#
# Specflow 프로젝트 생성
#
dotnet new specflowproject -h
dotnet new specflowproject -t xunit -f net6.0 -o {프로젝트명}
#  dotnet new specflowproject --unittestprovider xunit --framework net6.0 -o {프로젝트명}
```
- `dotnet new -i SpecFlow.Templates.DotNet`
- `dotnet new specflowproject -t xunit -f net6.0 -o {프로젝트명}`

## 템플릿 프로젝트 테스트
```cs
_scenarioContext.Pending();
```
- `Pending()` 메서드는 테스트 실패를 발생 시킨다.

```shell
오류 메시지:
  TechTalk.SpecFlow.xUnit.SpecFlowPlugin.XUnitPendingStepException : Test pending: One or more step definitions are not implemented yet.
  CalculatorStepDefinitions.GivenTheFirstNumberIs(50)

실패!  - 실패:     1, 통과:     0, 건너뜀:     0, 전체:     1, 기간: < 1 ms
```

## 참고 자료
- `dotnet new` 템플릿 명령
  - [dotnet new --list](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-new-list)
  - [dotnet new --install](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-new-install)
  - [dotnet new --uninstall](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-new-uninstall)
  - [dotnet new --update-*](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-new-update)
- `Specflow`
  - [Project-and-Item-Templates 문서](https://docs.specflow.org/projects/specflow/en/latest/Installation/Project-and-Item-Templates.html)
  - [SpecFlow.Templates.DotNet](https://www.nuget.org/packages/SpecFlow.Templates.DotNet/)
  - [Using SpecFlow in Visual Studio Code 동영상](https://www.youtube.com/watch?v=ldRM7f5j4HM)