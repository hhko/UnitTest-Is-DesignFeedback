using Microsoft.EntityFrameworkCore;

namespace HelloEFCore;

public class DemoContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=postgres");
    }
}