# 단위 테스트와!
## 목표
- 지속 가능한 성장을 위한 **설계를** 구현하고 검증할 수 있다.

## 목차
### Part 0. 개발 환경 구축하기
- .NET SDK([링크](https://dotnet.microsoft.com/en-us/download/dotnet))
- Visual Studio Code([링크](https://code.visualstudio.com/download))
- Visual Studio Code 확장 도구
  - 프로그래밍 언어
    - C#([링크](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp))
  - 단위 테스트
    - .NET Core Test Explorer([링크](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer))
    - Coverage Gutters([링크](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters))

### Part 1. 단위 테스트 기초 다지기
#### Chapter 1. 단위 테스트
- [x] Step 01. 단위 테스트 구성([구현](./Part01/Ch01/Step01/))
- [x] Step 02. 단위 테스트 성공과 실패([구현](./Part01/Ch01/Step02/))
- [x] Step 03. 단위 테스트 디버깅([구현](./Part01/Ch01/Step03/))
- [x] Step 04. 단위 테스트 확장 도구([구현](./Part01/Ch01/Step04/))
- [x] Step 05. 단위 테스트 출력([구현](./Part01/Ch01/Step05/))
- [x] Step 06. 단위 테스트 격리 실행([구현](./Part01/Ch01/Step06/))
- [x] Step 07. 단위 테스트 병렬 실행([구현](./Part01/Ch01/Step07/))
- [x] Step 08. 단위 테스트 구현 패턴([구현](./Part01/Ch01/Step08/))
- [x] Step 09. 단위 테스트 Fluent Assertion([구현](./Part01/Ch01/Step09/))

#### Chapter 2. 코드 커버리지
- [ ] 코드 커버리지 단일 프로젝트 명령
- [ ] 코드 커버리지 복수 프로젝트 명령
- [ ] 코드 커버러지 HTML 명령
- [ ] 코드 커버리지 VSCode 옵션
- [ ] 코드 커버리지 Live

#### Chapter 3. GitHub & GitLab CI 통합
- [ ] GitHub 빌드
- [ ] GitHub 코드 커버리지
- [ ] GitHub 코드 커러비리 결과
- [ ] GitLab 빌드
- [ ] GitLab 코드 커버리지
- [ ] GitLab 코드 커버리지 결과

---

### Part 2. 단위 테스트 패키지 이해하기
#### Chapter 4. 단위 테스트 패키지 xUnit
- 설정
- 내부 N개 입력
- 외부 N개 입력
- 데이터 공유
- 순서 지정
- 직렬 실행
- 대기 최대 시간

#### Chapter 5. 단위 테스트 Arrange 패키지 AutoFixture

#### Chapter 6. 단위 테스트 Architecture 패키지 ArchiUnitNET

#### Chapter 7. 단위 테스트 Container 패키지 DotNet.Testcontainers

---

### Part 3. 단위 테스트와 설계

#### Chapter ?. 설계 원칙
- [ ] 역할과 책임
- [ ] 분리
- [ ] 협력
- [ ] 의존성 역전
- [ ] 의존성 주입
- [ ] 단위 테스트 Best Practice

#### Chapter ?. 도메인 주도 설계

#### Chapter ?. 클린 아키텍처

---

### Part 4. 프로젝트

#### Chapter ?. Tic Tac Toe
#### Chapter ?. Tetris
#### Chapter ?. ?

<br/>

## 참고 자료
- [ ] [Coverlet integration with MSBuild](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/MSBuildIntegration.md)
- [ ] [Create a GitHub Action with .NET](https://docs.microsoft.com/en-us/dotnet/devops/create-dotnet-github-action)
- [ ] [.NET Core 및.NET 표준을 사용하는 단위 테스트 모범 사례](https://docs.microsoft.com/ko-kr/dotnet/core/testing/unit-testing-best-practices)
- [ ] [.NET CLI를 사용하여 프로젝트 구성 및 테스트](https://docs.microsoft.com/ko-kr/dotnet/core/tutorials/testing-with-cli)
- [ ] [Attribute [CollectionDefinition(DisableParallelization = true)] doesn't prevent parallel execution between class #1999](https://github.com/xunit/xunit/issues/1999#issuecomment-522635397)
- [ ] [xUnit: Control the Test Execution Order](https://hamidmosalla.com/2018/08/16/xunit-control-the-test-execution-order/)
- [ ] [Execute unit tests serially (rather than in parallel)](https://www.titanwolf.org/Network/q/3c8bf31e-3cfe-4929-809c-24ac9dbc7fca/y)
- xUnit Document
  - [ ] [Getting Started with xUnit.net, Using .NET Core with the .NET SDK command line](https://xunit.net/docs/getting-started/netcore/cmdline)
  - [ ] [Getting Started with xUnit.net, Using .NET Core with Visual Studio](https://xunit.net/docs/getting-started/netcore/visual-studio)
  - [ ] [Configuration Files](https://xunit.net/docs/configuration-files)
  - [ ] [Running Tests in Parallel](https://xunit.net/docs/running-tests-in-parallel)
  - [ ] [Shared Context between Tests](https://xunit.net/docs/shared-context)
  - [ ] [samples.xunit](https://github.com/xunit/samples.xunit)
  - [ ] [Capturing Output](https://xunit.net/docs/capturing-output)
  - [ ] [Running xUnit.net tests in MSBuild](https://xunit.net/docs/running-tests-in-msbuild) 
- by Hamid Mosalla
  - [ ] [XUnit – Part 8: Using TheoryData Instead of MemberData and ClassData](https://hamidmosalla.com/2020/04/05/xunit-part-8-using-theorydata-instead-of-memberdata-and-classdata/)
  - [ ] [XUnit – Part 7: Categorizing Tests with xUnit Trait](https://hamidmosalla.com/2020/03/01/xunit-part-7-categorizing-tests-with-xunit-trait/)
  - [ ] [XUnit – Part 6: Testing The Database with xUnit Custom Attributes](https://hamidmosalla.com/2020/02/16/xunit-part-6-testing-the-database-with-xunit-custom-attributes/)
  - [ ] [XUnit – Part 5: Share Test Context With IClassFixture and ICollectionFixture](https://hamidmosalla.com/2020/02/02/xunit-part-5-share-test-context-with-iclassfixture-and-icollectionfixture/)
  - [ ] [XUnit – Part 4: Parallelism and Custom Test Collections](https://hamidmosalla.com/2020/01/26/xunit-part-4-parallelism-and-custom-test-collections/)
  - [ ] [XUnit – Part 3: Action Based Assertions Assert.Raises and Assert.Throws](https://hamidmosalla.com/2020/01/20/xunit-part-3-action-based-assertions-assert-raises-and-assert-throws/)
  - [ ] [XUnit – Part 2: Value and Type Based Assertions in xUnit](https://hamidmosalla.com/2020/01/12/xunit-part-2-value-and-type-based-assertions-in-xunit/)
  - [ ] [XUnit – Part 1: xUnit Packages and Writing Your First Unit Test](https://hamidmosalla.com/2020/01/05/xunit-part-1-xunit-packages-and-writing-your-first-unit-test/)

## 단위 테스트 패키지
- [x] 단위 테스트 | xUnit
- [x] 단위 테스트 | Fluent Assertions
- [ ] 단위 테스트 | AutoFixture
- [ ] 단위 테스트 | ApprovalTests.Net
- [ ] 단위 테스트 | Moq
- [ ] 단위 테스트 | ArchiUnitNET
- [ ] 컨테이너 | DotNet.Testcontainers
---
- [ ] 데이터 | Bogus
- [ ] 로그 | Serilog.Sinks.InMemory
---
- [ ] 웹 | Playwright-dotnet
- [ ] 웹 | bUnit
- [ ] 성능 | NBomber
- [ ] 성능 | siege
- [ ] 성능 | NBench
- [ ] 데이터베이스 | Respawn
- [ ] 데이터베이스 | EFCore?

## dotnet test 명령
```
dotnet test
dotnet test --no-build

// Logger : ITestOutputHelper
dotnet test --logger "console;verbosity=detailed"

dotnet test --configuration Release
dotnet test -c Release
```
- [ ] [dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)
  ```
  --arch ?
  --framework ?
  --verbosity=minimal
  ```
