
## 명령 요약
```shell
# 프로젝트 구성
dotnet new sln -n UnitTest3aPattern
dotnet new console -o CalculatorApp
dotnet new classlib -o CalculatorLib
dotnet new xunit -o CalculatorLib.UnitTest

# 솔루션 구성
dotnet sln add .\CalculatorApp
dotnet sln add .\CalculatorLib
dotnet sln add .\CalculatorLib.UnitTest

# 솔루션 빌드
dotnet build
dotnet run --project .\CalculatorApp

# 솔로션 테스트 실행
dotnet test
dotnet test --no-build --no-restore
```