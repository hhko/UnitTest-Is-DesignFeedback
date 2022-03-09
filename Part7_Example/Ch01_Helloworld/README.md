# Helloworld

## 도구 설치
```shell
#
# 1. Nuke 도구 설치
#    https://nuke.build/docs/getting-started/setup.html
#
dotnet tool install -g Nuke.GlobalTool

#
# 2. Visual Studio Code 확장 도구 설치
#    NUKE Support : https://marketplace.visualstudio.com/items?itemName=nuke.support
#
```

## 예제 구성 명령
```shell
#
# 1. 솔루션 생성
#
dotnet new sln -n Helloworld

#
# 2. 프로젝트 생성
#
dotnet new console -o .\src\HelloworldApp
dotnet new classlib -o .\src\Helloworld
dotnet new xunit -o .\tests\Helloworld.UnitTest
dotnet new xunit -o .\tests\Helloworld.IntegratedTest

#
# 3. 프로젝트 참조 추가
#
dotnet add .\src\HelloworldApp reference .\src\Helloworld
dotnet add .\tests\Helloworld.UnitTest reference .\src\Helloworld

#
# 4.1 단위 테스트 프로젝트 패키지 추가
#
dotnet add .\tests\Helloworld.UnitTest package coverlet.msbuild
dotnet add .\tests\Helloworld.UnitTest package FluentAssertions
dotnet add .\tests\Helloworld.UnitTest package JunitXml.TestLogger

#
# 4.2 통합 테스트 프로젝트 패키지 추가
#
dotnet add .\tests\Helloworld.IntegratedTest package coverlet.msbuild
dotnet add .\tests\Helloworld.IntegratedTest package FluentAssertions
dotnet add .\tests\Helloworld.IntegratedTest package JunitXml.TestLogger
dotnet add .\tests\Helloworld.IntegratedTest package CliWrap

#
# 5. 솔루션 구성
#
dotnet sln add .\src\HelloworldApp
dotnet sln add .\src\Helloworld
dotnet sln add .\tests\Helloworld.UnitTest
dotnet sln add .\tests\Helloworld.IntegratedTest

#
# 6. 빌드 프로젝트 생성
#
# Nuke는 기본적으로 .git 폴더가 있는 경로를 빌드 루트로 인식한다.
# 명시적으로 빌드 루트를 변경하려면 `--root` 옵션으로 지정할 수 있다.
nuke :setup --root .

#  How should the build project be named?
#  ￢  _build
#  Where should the build project be located?
#  ￢  ./.build
#  Which NUKE version should be used?
#  ￢  6.0.1 (latest release)
#  Which solution should be the default?
#  ￢  Helloworld.sln
#  Do you need help getting started with a basic build?
#  ￢  Yes, get me started!
#  Restore, compile, pack using ...
#  ￢  dotnet CLI
#  Source files are located in ...
#  ￢  ./src
#  Move packages to ...
#  ￢  ./artifacts
#  Where do test projects go?
#  ￢  ./tests
#  Do you use git?
#  ￢  No, something else

#
# 7. 빌드
#
build.cmd
build.cmd --configuration Release
build.cmd clean
build.cmd test

#
# 8. 프로그램 실행
#
dotnet run --project .\src\HelloworldApp\
```
- `nuke :setup --root .` : 명시적으로 빌드 루트 경로를 지정해야 한다.

## 기본 코드
### 프로그램
```cs
public static void Main(string[] args)
{
    // Impure : I/O
    WriteLine("Enter your name: ");

    // Pure
    Greeting greeting = new Greeting();
    string message = greeting.For(ReadLine());

    // Impure : I/O
    WriteLine(message);
}
```

### Pure 메서드
```cs
public class Greeting
{
    public string For(string? name)
    {
        return $"Hello {name}";
    }
}
```

## 단위 테스트 : 메모리 테스트
```cs
public class GreetingSpec
{
    [Theory]
    [InlineData("Foo", "Hello Foo")]
    [InlineData("", "Hello ")]
    [InlineData(null, "Hello ")]
    public void Succeed(string input, string expected)
    {
        // Arrange
        Greeting sut = new Greeting();

        // Act
        string actual = sut.For(input);

        // Assert
        actual.Should().Be(expected);
    }
}
```

## 통합 테스트 : 프로세스 테스트
```cs
public class HelloworldAppSpec
{
    [Theory]
    [InlineData("Foo", "Hello Foo\r\n")]    // 프로세스 테스트에서는 "\r\n"까지 검증 대상이다.
    [InlineData("", "Hello \r\n")]
    //[InlineData(null, "Hello \r\n")]      // PipeSource.FromString(input)에서 NULL을 처리할 수 없다.
    public async Task Succeed(string input, string expected)
    {
        var stdOutBuffer = new StringBuilder();

#if DEBUG
        var result = await Cli.Wrap(@".\..\..\..\..\..\src\HelloworldApp\bin\Debug\net6.0\HelloworldApp.exe")
#else
        var result = await Cli.Wrap(@".\..\..\..\..\..\src\HelloworldApp\bin\Release\net6.0\HelloworldApp.exe")
#endif
            .WithStandardInputPipe(PipeSource.FromString(input))
            .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
            .ExecuteAsync();

        stdOutBuffer.ToString()
            .Should()
            .EndWith(expected);
    }
}
```
