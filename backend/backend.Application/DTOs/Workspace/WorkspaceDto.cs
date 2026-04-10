namespace backend.Application.DTOs.Workspace;

public class WorkspaceDto
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

}