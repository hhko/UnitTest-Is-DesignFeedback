# SpecFlow Step Definition 생성하기

## 솔루션 폴더 구성
```
프로젝트
 - Features
    - ... .feature
 - Steps
    - ...StepDefinitions.cs
```

## Visual Studio Code 확장 도구
- Cucumber (Gherkin) Full Support([링크](https://marketplace.visualstudio.com/items?itemName=alexkrechik.cucumberautocomplete))
- [Specflow Steps Definition Generator](https://marketplace.visualstudio.com/items?itemName=RajUppadhyay.specflow-steps-definition-generator) 확장 도구

## settings.josn 파일
```json
{
    "cucumberautocomplete.steps": [
        "./**/Steps/**/*.cs"
    ]
}
```

## NuGet 패키지
- Specflow.xUnit([링크](https://www.nuget.org/packages/SpecFlow.xUnit/))

## Feature 디버깅
```shell
# TestHost 프로세스 디버깅 설정
$env:VSTEST_HOST_DEBUG=1

# 단위 테스트 실행
dotnet test .\HelloSpec.IntegratedTest\

# TestHost 프로세스 Id 확인
#
# 테스트 실행을 시작하는 중입니다. 잠시 기다려 주세요...
# 지정된 패턴과 일치한 총 테스트 파일 수는 1개입니다.
# 호스트 디버깅을 사용하도록 설정했습니다. testhost 프로세스를 계속하려면 디버거를 # 연결하세요.
# Process Id: 29664, Name: testhost

# TestHost 프로세스 연결
.NET Core Attach
```

## 참고 자료
- [Specflow Debugging](https://docs.specflow.org/projects/specflow/en/latest/vscode/vscode-debug.html)
- https://medium.com/@uppadhyayraj/specflow-integration-in-vs-code-single-ide-across-different-platforms-dac954aedf9e