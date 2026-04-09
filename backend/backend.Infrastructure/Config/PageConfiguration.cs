using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Config.EntityConfigurations;

public class PageConfiguration : IEntityTypeConfiguration<Page>
{
  public void Configure(EntityTypeBuilder<Page> builder)
  {
    builder.HasData(
        new Page
        {
          Id = 1,
          Title = "Home",
          Content = "Welcome to the workspace",
          Icon = "home",
          WorkspaceId = 1,
          CreatedById = 1,
          ParentPageId = null,
          IsDeleted = false,
          CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
          UpdatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
        },
        new Page
        {
          Id = 2,
          Title = "Getting Started",
          Content = "First page of the system",
          Icon = "book",
          WorkspaceId = 1,
          CreatedById = 1,
          ParentPageId = 1,
          IsDeleted = false,
          CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
          UpdatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
        }
    );
  }
}