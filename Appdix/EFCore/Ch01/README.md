# Getting Started With Entity Framework Core - Console
- https://www.learnentityframeworkcore.com/walkthroughs/console-application
- https://docs.microsoft.com/ko-kr/ef/core/cli/dotnet#update-the-tools

## 프로젝트 구성
- 패키지 추가
  ```shell
  dotnet add .\HelloEFCore\ package Npgsql.EntityFrameworkCore.PostgreSQL
  dotnet add .\HelloEFCore\ package Microsoft.EntityFrameworkCore.Tools
  ```
  - https://github.com/npgsql/efcore.pg

- ~~.csproj 파일 수정~~
  ```xml
  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.1" />
  </ItemGroup>
  ```

## dotnet-ef 도구
```shell
# 도구 설치
dotnet tool install -g dotnet-ef

# C# 코드 생성 : dotnet-ef migrations add [이름]
dotnet-ef migrations add CreateDatabase --project .\HelloEFCore\
dotnet-ef migrations list
dotnet-ef migrations remove ..?

# DB 스키마 생성
dotnet-ef database update --project .\HelloEFCore\
dotnet ef database drop?
```

## PostgreSQL 접속
```cs
public class DemoContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=postgres");
    }
}
```

## C# 코드 vs. PostgreSQL 스키마
- [ ] `TODO?` C# -관계정의?-> PostgreSQL
  ```cs
  public ICollection<Book> Books { get; set; } = new List<Book>();
  public Author Author { get; set; }
  ```
- [x] `TODO?` 제약 조건
  ```cs
  [StringLength(50)]
  public string FirstName { get; set; }
  ```
  ```cs
  public partial class LimitStrings2 : Migration
  {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.AlterColumn<string>(
              name: "Title",
              table: "Books",
              type: "character varying(255)",
              maxLength: 255,
              nullable: false,
              oldClrType: typeof(string),
              oldType: "text");
  ```
- `TODO?` 제약조건 분리
  - 변경 전 : 필드 Attribute
  - 변경 후 : 제약조건 정의 override 메서드?




