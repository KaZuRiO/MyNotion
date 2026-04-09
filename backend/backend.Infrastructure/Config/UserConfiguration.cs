using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Config.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasData(
        new User
        {
          Id = 1,
          Username = "admin",
          Email = "admin@example.com",
          Password = null,
          AvatarUrl = null,
          IsActive = true,
          CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
          UpdatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
        },
        new User
        {
          Id = 2,
          Username = "user1",
          Email = "user1@example.com",
          Password = null,
          AvatarUrl = null,
          IsActive = true,
          CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
          UpdatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
        }
    );
  }
}