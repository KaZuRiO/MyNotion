using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Config;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Page> Pages { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Page>().HasData(
        new Page { Id = 1, Title = "Page 1", Icon = "Icon 1", Content = "Content 1" },
        new Page { Id = 2, Title = "Page 2", Icon = "Icon 2", Content = "Content 2" }
    // Add more pages as needed
    );
  }
}
