namespace backend.Application.DTOs.Page;

public class CreatePageDto
{
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string? Icon { get; set; } = null;
  public int WorkspaceId { get; set; }
  public int CreatedById { get; set; }
  public int? ParentPageId { get; set; }
}