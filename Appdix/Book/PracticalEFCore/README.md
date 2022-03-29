
## NuGet 패키지
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Npgsql.EntityFrameworkCore.PostgreSQL

## dotnet ef 도구
```shell
#
# 도구 설치
#
dotnet tool install -g dotnet-ef

#
# Code-First
#
# C# 코드 생성 : dotnet-ef migrations add [이름]
dotnet ef migrations add CreateDatabase --project .\HelloEFCore\
dotnet ef migrations list
dotnet ef migrations remove ..?

# DB 스키마 생성
dotnet ef database update --project .\HelloEFCore\
dotnet ef database drop?

#
# Database-First
#
dotnet ef dbcontext scaffold `
    "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres" `
    Npgsql.EntityFrameworkCore.PostgreSQL `
    --context UsersDbContext  `
    --output-dir .\Models
```

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
