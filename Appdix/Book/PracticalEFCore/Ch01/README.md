# DbContext

### 패키지 설치
- `Microsoft.EntityFrameworkCore` 패키지 최신 버전 설치

### 사용자 정의 DbContext 클래스 생성
```cs
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }
}
```
- `DbContext` 상속
- `DbContextOptions options` 옵션 처리 생성자 정의