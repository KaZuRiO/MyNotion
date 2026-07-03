using backend.Domain.Entities;
using backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Config.EntityConfigurations;

public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
  public void Configure(EntityTypeBuilder<Block> builder)
  {
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Type)
            .HasConversion<string>()
            .IsRequired();
    builder.Property(x => x.Content)
            .IsRequired();
    builder.Property(x => x.Position)
            .HasColumnType("decimal(18,2)");
    builder.HasData(
      new Block{
          Id= 1,
          PageId= 1,
          Type= BlockType.Text,
          Position= 0m,
          Content= "Welcome to the workspace",
          ParentBlockId= null
      },
      new Block{
          Id= 2,
          PageId= 2,
          Type= BlockType.Text,
          Position= 1m,
          Content= "First block of the system",
          ParentBlockId= null
      }
    );
  }
}