# Database First

## 패키지 설치
- App
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.EntityFrameworkCore.Tools
  - Npgsql.EntityFrameworkCore.PostgreSQL
  - Microsoft.Extensions.Configuration
  - Microsoft.Extensions.Configuration.FileExtensions
  - Microsoft.Extensions.Configuration.Json
- Classlibrary
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Tools
  - Npgsql.EntityFrameworkCore.PostgreSQL

## Database First(scaffold)
```shell
dotnet ef dbcontext scaffold "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres" Npgsql.EntityFrameworkCore.PostgreSQL --context UsersDbContext
```
- 참고 자료
  - https://docs.microsoft.com/ko-kr/ef/core/cli/dotnet#dotnet-ef-dbcontext-scaffold
  - https://docs.microsoft.com/ko-kr/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
- `dotnet ef dbcontext scaffold` `<CONNECTION>` `<PROVIDER>` `<OPTION>` ...
  - `<CONNECTION>` : "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres"
  - `<PROVIDER>` : Npgsql.EntityFrameworkCore.PostgreSQL
  - `<OPTION>`
    - `--schema` [데이터베이스 이름]
    - `--table` [테이블 이름]
    ---
    - `--context` [... DbContext 클래스 이름]
    - `--context-namespace` [... DbContext 클래스 네임스페이스 이름]
    - `--context-dir` [... DbContext 클래스 출력 경로]
    ---
    - `--namespace` [테이블 클래스 네임스페이스 이름]
    - `--output-dir` [테이블 클래스 출력 경로]
    ---
    - `--force`
    - `--data-annotations`

## appsettings.json 환경 파일
```cs
static IConfigurationRoot _configuration;
static DbContextOptionsBuilder<UsersDbContext> _optionsBuilder;

static void BuildConfiguration()
{
    string v = Directory.GetCurrentDirectory();
    var builder = new ConfigurationBuilder()                                        // Microsoft.Extensions.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())                               // Microsoft.Extensions.Configuration.FileExtensions
        .AddJsonFile("appsettings.json",                                            // Microsoft.Extensions.Configuration.Json
            optional: true,                 // 파일 존재 유/무
            reloadOnChange: true);          // 파일 변경 인식 유/무

    _configuration = builder.Build();
}

static void BuildOptions()
{
    _optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
    _optionsBuilder.UseNpgsql(_configuration.GetConnectionString("AdventureWorks"));
}

using var db = new UsersDbContext(_optionsBuilder.Options);
```
- `IConfigurationRoot` -(appsettings.json)-> `DbContextOptionsBuilder` -(PostgreSQL)-> `사용자 정의 DbContext`