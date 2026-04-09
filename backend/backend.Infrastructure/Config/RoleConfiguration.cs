using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Config.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.HasData(
        new Role
        {
          Id = 1,
          Name = "Owner",
          Priority = 3
        },
        new Role
        {
          Id = 2,
          Name = "Admin",
          Priority = 2
        },
        new Role
        {
          Id = 3,
          Name = "Member",
          Priority = 1
        }
    );
  }
}