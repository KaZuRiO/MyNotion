namespace backend.Application.DTOs.Page;

public class PageDto
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string? Content { get; set; } = string.Empty;
  public string? Icon { get; set; } = null;
  public int? ParentPageId { get; set; }
  public int? WorkspaceId { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
}