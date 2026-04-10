namespace backend.Domain.Entities;

public class Role
{
  public int Id { get; set; }

  public string Name { get; set; } = string.Empty;

  public int Priority { get; set; } = 0;

  public List<Workspace_User> Workspace_Users { get; set; } = new();
}