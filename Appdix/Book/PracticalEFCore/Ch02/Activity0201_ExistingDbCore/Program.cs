using DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Activity0201_ExistingDbCore;

public class Program
{
    static IConfigurationRoot _configuration;
    static DbContextOptionsBuilder<UsersDbContext> _optionsBuilder;

    static void Main(string[] args)
    {
        BuildConfiguration();
        BuildOptions();
        ListUsers();

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

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

    static void ListUsers()
    {
        using var db = new UsersDbContext(_optionsBuilder.Options);

        var users = db.Users.OrderByDescending(x => x.Name).Take(20).ToList();

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name} {user.Created}");
        }
    }
}
