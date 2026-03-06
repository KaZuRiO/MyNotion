using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL; // ✅ required for UseNpgsql

namespace backend.Infrastructure.Config;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{

  public AppDbContext CreateDbContext(string[] args)
  {
    var db = Environment.GetEnvironmentVariable("DATABASE_POSTGRES");
    var user = Environment.GetEnvironmentVariable("USER_POSTGRES");
    var pass = Environment.GetEnvironmentVariable("PASSWORD_POSTGRES");

      
    var connectionString = $"Host=postgres;Port=5432;Database={db};Username={user};Password={pass}";
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

    optionsBuilder.UseNpgsql(connectionString);

    return new AppDbContext(optionsBuilder.Options);
  }
}