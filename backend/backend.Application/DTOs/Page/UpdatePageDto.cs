namespace backend.Application.DTOs.Page;
public class UpdatePageDto
{
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string? Icon { get; set; } = null;
  public int? ParentPageId { get; set; }
}