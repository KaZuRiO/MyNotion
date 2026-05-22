namespace backend.Domain.Entities;

public class Page
{
  public int Id { get; set; }

  public string Title { get; set; } = string.Empty;
  public string? Content { get; set; }
  public string? Icon { get; set; }
  public int? ParentPageId { get; set; }
  public Page? ParentPage { get; set; }
  public List<Page> ChildPages { get; set; } = new();
  public int WorkspaceId { get; set; }
  public Workspace Workspace { get; set; } = null!;
  public int CreatedById { get; set; }
  public User CreatedBy { get; set; } = null!;

  public bool IsDeleted { get; set; } = false;

  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}