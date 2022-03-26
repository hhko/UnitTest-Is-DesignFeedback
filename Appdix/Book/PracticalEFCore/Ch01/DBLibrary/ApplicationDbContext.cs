using Microsoft.EntityFrameworkCore;

namespace DBLibrary;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }
}
