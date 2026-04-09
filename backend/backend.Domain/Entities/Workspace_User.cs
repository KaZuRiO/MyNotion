namespace backend.Domain.Entities;

public class Workspace_User
{
  public int Id { get; set; }

  public int WorkspaceId { get; set; }
  public Workspace Workspace { get; set; }

  public int UserId { get; set; }
  public User User { get; set; }

  public int RoleId { get; set; }
  public Role Role { get; set; }
}