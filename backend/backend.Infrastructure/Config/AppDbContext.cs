using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Config;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users => Set<User>();
  public DbSet<Workspace> Workspaces => Set<Workspace>();
  public DbSet<Page> Pages => Set<Page>();
  public DbSet<Role> Roles => Set<Role>();
  public DbSet<WorkspaceUser> WorkspaceUsers => Set<WorkspaceUser>();
  public DbSet<Block> Blocks => Set<Block>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
  }
}