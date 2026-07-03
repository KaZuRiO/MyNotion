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
          Firstname = "Admin",
          Lastname = "User",
          Email = "admin@example.com",
          Password = BCrypt.Net.BCrypt.HashPassword("test"),
          AvatarUrl = null,
          IsActive = true,
          CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
          UpdatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
        },
        new User
        {
          Id = 2,
          Username = "user1",
          Firstname = "User",
          Lastname = "One",
          Email = "user1@example.com",
          Password = BCrypt.Net.BCrypt.HashPassword("test"),
          AvatarUrl = null,
          IsActive = true,
          CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
          UpdatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
        }
    );
  }
}