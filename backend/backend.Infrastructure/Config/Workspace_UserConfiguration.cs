using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Config.EntityConfigurations;

public class WorkspaceUserConfiguration : IEntityTypeConfiguration<Workspace_User>
{
  public void Configure(EntityTypeBuilder<Workspace_User> builder)
  {
    builder.HasData(
        new Workspace_User
        {
          Id = 1,
          WorkspaceId = 1,
          UserId = 1,
          RoleId = 1 
        },
        new Workspace_User
        {
          Id = 2,
          WorkspaceId = 1,
          UserId = 2,
          RoleId = 2
        }
    );
  }
}