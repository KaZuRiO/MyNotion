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
          Password = "$2a$11$VwicNuYDsGwmmD.gu5XcUOIhEPhWN.8m3CNrqFZL2A.miC0tBk4Oy",
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
          Password = "$2a$11$fiSktqtzdzVYGAr23Y2n4ete/Df8jSTRqR0TtQq5ZNXoWGc8M93FG",
          AvatarUrl = null,
          IsActive = true,
          CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
          UpdatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
        }
    );
  }
}