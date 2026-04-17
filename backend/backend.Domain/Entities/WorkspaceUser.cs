namespace backend.Domain.Entities;

public class WorkspaceUser
{
  public int Id { get; set; }

  public int WorkspaceId { get; set; }
  public Workspace Workspace { get; set; }

  public int UserId { get; set; }
  public User User { get; set; }

  public int RoleId { get; set; }
  public Role Role { get; set; }
  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

}