using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL; // ✅ required for UseNpgsql

namespace backend.Infrastructure.Config;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

    optionsBuilder.UseNpgsql(
        "Host=postgres;Port=5432;Database=postgres;Username=postgres;Password=postgres");

    return new AppDbContext(optionsBuilder.Options);
  }
}