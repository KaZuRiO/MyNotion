using System.Reflection.Metadata;

namespace backend.Domain.Entities;

public class WorkspaceUser
{
  public int Id { get; set; }

  public int WorkspaceId { get; set; }
  public Workspace Workspace { get; set; } = null!;

  public int UserId { get; set; }
  public User User { get; set; } = null!;

  public int RoleId { get; set; }
  public Role Role { get; set; } = null!;

  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}