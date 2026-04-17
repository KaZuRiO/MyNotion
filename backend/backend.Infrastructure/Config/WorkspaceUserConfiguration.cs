using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Config.EntityConfigurations;

public class WorkspaceUserConfiguration : IEntityTypeConfiguration<WorkspaceUser>
{
  public void Configure(EntityTypeBuilder<WorkspaceUser> builder)
  {
    builder.HasData(
        new WorkspaceUser
        {
          Id = 1,
          WorkspaceId = 1,
          UserId = 1,
          RoleId = 1
        },
        new WorkspaceUser
        {
          Id = 2,
          WorkspaceId = 1,
          UserId = 2,
          RoleId = 2
        }
    );
  }
}