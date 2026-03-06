using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Config.EntityConfigurations;

public class PageConfiguration : IEntityTypeConfiguration<Page>
{
  public void Configure(EntityTypeBuilder<Page> builder)
  {
    builder.HasData(
        new Page { Id = 1, Title = "Page 1", Icon = "Icon 1", Content = "Content 1" },
        new Page { Id = 2, Title = "Page 2", Icon = "Icon 2", Content = "Content 2" }
    );
  }
}