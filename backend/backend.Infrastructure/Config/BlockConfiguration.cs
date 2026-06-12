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
      new Block(
          id: 1,
          pageId: 1,
          type: BlockType.Text,
          position: 0m,
          content: "Welcome to the workspace",
          parentBlockId: null
      ),
      new Block(
          id: 2,
          pageId: 2,
          type: BlockType.Text,
          position: 1m,
          content: "First block of the system",
          parentBlockId: null
      )
    );
  }
}