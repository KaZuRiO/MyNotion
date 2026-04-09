using System.Collections.Generic;
using backend.Domain.Entities;    

public class Role
{
  public int Id { get; set; }

  public string Name { get; set; }

  public int Priority { get; set; }

  public List<Workspace_User> Workspace_Users { get; set; } = new();
}