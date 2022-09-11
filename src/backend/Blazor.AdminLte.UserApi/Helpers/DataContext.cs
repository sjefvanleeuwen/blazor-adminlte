namespace Blazor.AdminLte.UserApi.Helpers;

using Blazor.AdminLte.Security.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseInMemoryDatabase("WebApiDatabase");
        //options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }
}