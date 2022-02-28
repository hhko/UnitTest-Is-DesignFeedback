## 목차
- Nuke란
- Nuke 사용 목적
- Nuke 설치
- Nuke 빌드 프로젝트 생성
- Nuke 소스 구성
  - Parameter 추가
  - 로그 출력
- Nuke 명령
- Nuke FAQ
- 참고 동영상

## Nuke란?
- .NET 솔루션 빌드 자동화를 제공하기 위해 C# 도메인 특화 언어(DSL : Domain-Specific Language)입니다.  
  `The cross-platform build automation solution for .NET with C# DSL.`  
- 빌드 자동화를 위한 스크립트를 도메인 지식(빌드) 중심으로 작성합니다.
- 도메인 지식(빌드)에 집중할 수 있도록 C# 클래스를 제공합니다.

## Nuke 사용 목적
- 빌드를 코드로 문서화(자동화)한다.
- GitLab과 GitHub 등 외부 CI 의존성을 최소화시킨다.
- CI 서버와 Local 빌드를 통일 시킨다.
 
## Nuke 설치
- .NET Tool 설치
  ```shell
  # 설치
  dotnet tool install --global Nuke.GlobalTool

  # 확인
  dotnet tool list --global
  ```
- VSCode 확장 도구 설치
  - [NUKE Support](https://marketplace.visualstudio.com/items?itemName=nuke.support)

## Nuke 빌드 프로젝트 생성
```
# 기본적으로 솔루션 파일이 있는 폴더에서 실행시킨다.
nuke :setup
NUKE Global Tool version 6.0.1 (Windows,.NETCoreApp,Version=v3.1)
Could not find root directory. Falling back to working directory ...
```

| 템플릿 질문 | 설명 | 기본 값 | 선택 값 |
|---|---|---|---|
| How should the build project be named?                | 빌드 솔루션 파일명     | `_build`  |       |
| Where should the build project be located?            | 빌드 솔루션 위치       | `./build` |       |
| Which NUKE version should be used?                    | Nuke 버전             | `6.0.1`   |       |
| Which solution should be the default?                 | 빌드 대상 솔루션 선택   |          | `.sln` |
| Do you need help getting started with a basic build?  | 빌드 기본 코드         |           |        |
| Restore, compile, pack using ...                      | 빌드 도구 선택         |           | `dotnet CLI`, `MSBuild/Mono` |
| Source files are located in ...                       | 소스 폴더 선택         |           | `./source`, `./src` |
| Move packages to ...                                  | 패키지 폴더 선택       |           | `./output`, `./artifacts` |
| Where do test projects go?                            | 테스트 소스 폴더 선택   |          | `./tests` |
| Do you use git?                                       | Git 사용 유/무 선택    |          |         |
| Do you use GitVersion?                                | GitVersion 선택        |          |         |

```
How should the build project be named?
»                 [default: _build]
Where should the build project be located?
»                 [default: ./build]
Which NUKE version should be used?
»  6.0.1 (latest release)
Which solution should be the default?
»  {찾은 솔루션 파일명}.sln
   None
Do you need help getting started with a basic build?
»  Yes, get me started!
   No, I can do this myself...  
Restore, compile, pack using ...
»  dotnet CLI
   MSBuild/Mono
   Neither   
Source files are located in ...
»  ./source
   ./src
   Neither   
Move packages to ...
»  ./output
   ./artifacts
   Neither   
Where do test projects go?
»  ./tests
   Same as source   
Do you use git?
»  Yes, just not setup yet
   No, something else   
Do you use GitVersion?
»  Yes, just not setup yet
   No, custom versioning   
```
- 자동으로 생성되는 파일 목록
  - `build` 폴더 : build 소스 폴더
  - `build.cmd` 파일 : build.ps1 실행을 위한 파일
  - `build.ps1` 파일 : Windows에서 build 프로젝트 실행을 위한 스크립트 파일
  - `build.sh` 파일 : Linux에서 build 프로젝트 실행을 위한 스크립트 파일
  - `.nuke` : nuke 관리 폴더

## Nuke 소스 구성
```cs
// 실행 Target 지정
public static int Main () => Execute<Build>(x => x.Compile);

// 솔루션 파일
[Solution] readonly Solution Solution;

// IsServerBuild
// IsLocalBuild
readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

Target Clean => _ => _
    .Before(Restore)
    .Executes(() =>
    {
        // ...    
    });

Target Restore => _ => _
    .Executes(() =>
    {
        // ...
    });

Target Compile => _ => _
    .DependsOn(Restore)
    .Executes(() =>
    {
        // ...
    });
```

### Parameter 추가
```cs
[Parameter("Hello Parameter")]
readonly string Hello;
```
```
.\build.cmd --help
 
Parameters:
  --hello                 Hello Parameter.
```

### 로그 출력
```cs
using Serilog;

Log.Information("로그 출력");
```
```shell
15:27:04 [INF] 로그 출력
```

## Nuke 명령
- `--help` : 도움말
- `--plan` : Target 시각화
  ![](./nuke-plan.png)
  
## Nuke FAQ
- 빌드 코드의 IntelliSense가 정상동작하지 않을 때
  - `./build` 프로젝트 위치에서 VSCode 열기한다.
  - `./build` 프로젝트 위치에서 VSCode을 열면 정상적으로 `IntelliSense`가 동작한다.
- 실행하기
  ```shell
  # Case 1. 파일 실행
  ./build.cmd
  ./build.cmd --configuation Release
  
  # Case 2. Nuke 실행
  nuke
  nuke --configuation Release
  ```
- `[WRN] : Could not complete checking build configurations within 500 milliseconds` 경고 메시지 제거하기
  - 변경 전
    ```cs
    [CheckBuildProjectConfigurations]
    ```
  - 변경 후
    ```cs
    [CheckBuildProjectConfigurations(TimeoutInMilliseconds = 2000)]
    ```
- 복수 솔루션 파일 처리하기
  - 변경 전
    ```cs
    [Solution()] readonly Solution Solution;
    ```
  - 변경 후
    ```cs
    [Solution("src1/Sample1.sln")] readonly Solution Solution1;
    [Solution("src2/Sample2.sln")] readonly Solution Solution2;
    ```

## 참고 동영상
- [Nuke — Designing a Build System with IDE Support in Mind](https://www.youtube.com/watch?v=N57Zjb5-08I)
- [NUKE - C# Build Automation System - Overview & Tutorial](https://www.youtube.com/watch?v=V5m4yPMjCtY)
- [NUKE: Build automation for C# developers](https://www.youtube.com/watch?v=7gEqxzD6hbs)
