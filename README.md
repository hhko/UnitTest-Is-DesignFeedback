# UnitTest-With
## 목표
단위 테스트 기반으로 설계하고 개발하자

## 목차
### Part 1. 단위 테스트
- [ ] Ch01. 단위 테스트란
- [x] Ch02. 단위 테스트 통과와 실패([구현](./Part01/Ch01))
- [ ] Ch03. 단위 테스트 개별 실행
- [x] Ch04. 단위 테스트 3A Pattern([구현](./Part01/Ch03))
- [ ] Ch05. 단위 테스트 Assertion 개선
- [ ] Ch06. 단위 테스트 Debugging
- [ ] Ch07. 단위 테스트 Live
- [ ] Ch08. 단위 테스트 Best Practice

### Part 2. 코드 커버리지
- [ ] 코드 커버리지 단일 프로젝트 명령
- [ ] 코드 커버리지 복수 프로젝트 명령
- [ ] 코드 커버러지 HTML 명령
- [ ] 코드 커버리지 VSCode 옵션

### Part 3. GitHub & GitLab CI 통합
- [ ] GitHub 빌드
- [ ] GitHub 코드 커버리지
- [ ] GitHub 코드 커러비리 결과
- [ ] GitLab 빌드
- [ ] GitLab 코드 커버리지
- [ ] GitLab 코드 커버리지 결과

### Part 4. xUnit 패키지

### Part 5. 단위 테스트와 설계
- [ ] 분리
- [ ] 의존성 역전
- [ ] 아키텍처

### Part ?. 통합 테스트

### Part ?. 예제

## 참고 자료
- [ ] [Coverlet integration with MSBuild](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/MSBuildIntegration.md)
- [ ] [Create a GitHub Action with .NET](https://docs.microsoft.com/en-us/dotnet/devops/create-dotnet-github-action)
- [ ] [.NET Core 및.NET 표준을 사용하는 단위 테스트 모범 사례](https://docs.microsoft.com/ko-kr/dotnet/core/testing/unit-testing-best-practices)
- [ ] [.NET CLI를 사용하여 프로젝트 구성 및 테스트](https://docs.microsoft.com/ko-kr/dotnet/core/tutorials/testing-with-cli)

## 단위 테스트 패키지
- [x] 단위 테스트 | xUnit
- [ ] 단위 테스트 | Fluent Assertions
- [ ] 단위 테스트 | ApprovalTests.Net
---
- [ ] 설계 | Moq
- [ ] 설계 | ArchiUnitNET
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
--arch ?
--framework ?
--configuration Release \
--no-restore \
--no-build \
--verbosity=minimal \
```