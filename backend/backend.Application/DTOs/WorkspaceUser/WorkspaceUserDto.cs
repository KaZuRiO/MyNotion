namespace backend.Application.DTOs.WorkspaceUser;

public class WorkspaceUserDto
{
  public int Id { get; set; }
  public int WorkspaceId { get; set; }
  public int UserId { get; set; }
  public int RoleId { get; set; }
  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

}