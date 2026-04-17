namespace backend.Application.DTOs.Workspace;

public class CreateWorkspaceDto
{
  public string Name { get; set; } = "New Workspace";
  public string? Description { get; set; } = string.Empty;
  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

}