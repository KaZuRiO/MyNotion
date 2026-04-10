namespace backend.Application.DTOs.Workspace_User;

public class CreateWorkspace_UserDto
{
  public int WorkspaceId { get; set; }

  public int UserId { get; set; }

  public int RoleId { get; set; }
  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

}