# 단위 테스트와!

[![Build](https://github.com/hhko/With-UnitTest/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hhko/With-UnitTest/actions/workflows/dotnet.yml)

> - [**Kent Beck은** 2003년에 TDD가 **단순한 설계를** 장려하고 **자신감을** 불어넣어준다고 말하였다.](https://ko.wikipedia.org/wiki/%ED%85%8C%EC%8A%A4%ED%8A%B8_%EC%A3%BC%EB%8F%84_%EA%B0%9C%EB%B0%9C)  
> - [Software engineer **Kent Beck** stated in 2003 that TDD encourages **simple designs** and inspires **confidence**.](https://en.wikipedia.org/wiki/Test-driven_development)  

- 단위 테스트는 **설계 피드백이다.**
  - 단순한 설계 : "지속 가능한 성장을 위한 설계(분업과 협업)"을 장려한다.
  - 자신감 : "회귀 버그"을 검증할 수 있어 "리팩토링" 할 수 있다.

## 목표
- 지속 가능한 성장을 위한 **설계를** 구현하고 검증할 수 있다.

## 목차
- [TODO](./TODO.md)

### Part 0. 개발 환경 구축하기
- .NET SDK([링크](https://dotnet.microsoft.com/en-us/download/dotnet))
- Visual Studio Code([링크](https://code.visualstudio.com/download))
- Visual Studio Code 확장 도구
  - 프로그래밍 언어
    - C#([링크](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp))
  - 단위 테스트
    - .NET Core Test Explorer([링크](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer))
    - Coverage Gutters([링크](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters))
    - Cucumber (Gherkin) Full Support([링크](https://marketplace.visualstudio.com/items?itemName=alexkrechik.cucumberautocomplete))
    - PlantUML?

### Part 1. 단위 테스트 기초 다지기
#### Chapter 1. 단위 테스트
- [x] Step 01. 단위 테스트 구성([구현](./Part1/Ch01/Step01/))
- [x] Step 02. 단위 테스트 VSCode 태스크([구현](./Part1/Ch01/Step02/))
- [x] Step 03. 단위 테스트 성공과 실패([구현](./Part1/Ch01/Step03/))
- [x] Step 04. 단위 테스트 디버깅([구현](./Part1/Ch01/Step04/))
- [x] Step 05. 단위 테스트 VSCode 확장 도구([구현](./Part1/Ch01/Step05/))
- [x] Step 06. 단위 테스트 출력([구현](./Part1/Ch01/Step06/))
- [x] Step 07. 단위 테스트 격리 실행([구현](./Part1/Ch01/Step07/))
- [x] Step 08. 단위 테스트 병렬 실행([구현](./Part1/Ch01/Step08/))
- [x] Step 09. 단위 테스트 구현 패턴([구현](./Part1/Ch01/Step09/))
- [x] Step 10. 단위 테스트 Fluent Assertion([구현](./Part1/Ch01/Step10/))

#### Chapter 2. 코드 커버리지
- [ ] 코드 커버리지 단일 프로젝트 명령
- [ ] 코드 커버리지 복수 프로젝트 명령
- [ ] 코드 커버러지 HTML 명령
- [ ] 코드 커버리지 VSCode 옵션
- [ ] 코드 커버리지 Live

#### Chapter 3. GitHub & GitLab CI 통합
- [ ] Nuke
- [ ] GitHub CI
- [ ] GitHub 코드 커버리지 Badge
- [ ] GitLab CI
- [ ] GitLab 코드 커버리지 Badge

---

### Part 2. 단위 테스트 패키지 이해하기
#### Chapter 4. 단위 테스트 패키지 xUnit
- 설정
- Lifecycle
- 내부 N개 입력
- 외부 N개 입력
- 데이터 공유
- 순서 지정
- 직렬 실행
- 대기 최대 시간
- xUnit 인터페이스

#### Chapter 5. Arrange 단위 테스트 패키지 AutoFixture
- 생성자 변화
- 임의 데이터

#### Chapter 6. Mutation 단위 테스트 패키지 Stryker.NET

#### Chapter 7. Architecture 단위 테스트 패키지 ArchiUnitNET
- 의존성 검증

---

### Part 3. 통합 테스트 패키지 이해하기
#### Chapter ?. Console 통합 테스트 패키지 CliWrap

#### Chapter ?. Container 통합 테스트 패키지 DotNet.Testcontainers
- [x] Step 01. WebAPI 호스트 디버깅([구현](./Part3/Ch01/Step01/))
- [x] Step 02. WebAPI 컨테이너 디버깅([구현](./Part3/Ch01/Step02/))
- [x] Step 03. Console 컨테이너 디버깅([구현](./Part3/Ch01/Step03/))

#### Chapter ?. Behaviour 통합 테스트 패키지 Specflow

#### Chapter ?. Performance 통합 테스트 패키지 NBench

#### Chapter ?. Snapshot 통합 테스트 패키지 ApprovalTests.Net

#### Chapter ?. Web 통합 테스트 패키지 Playwright

#### Chapter ?. Load 통합 테스트 패키지 ?.

#### Chapter ?. Database 통합 테스트 패키지 ?.

---

### Part 4. 단위 테스트와 함께 설계하기
#### Chapter ?. 설계 원칙
- [ ] 분업(캡슐화 : 역할과 책임)
- [ ] 협업(의존성 : 상속과 위임)
- [ ] 의존성 역전
- [ ] 의존성 주입
- [ ] 단위 테스트 Best Practice

#### Chapter ?. 도메인 주도 설계

#### Chapter ?. 클린 아키텍처

---

### Part 5. 프로젝트
#### Chapter ?. Password Validation
#### Chapter ?. Tic Tac Toe
#### Chapter ?. Tetris
#### Chapter ?. eShop
#### Chaprer ?. ?
