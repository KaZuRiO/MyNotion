using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace backend.Domain.Entities;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
  public int Id { get; set; }

  public string Username { get; set; }

  [EmailAddress]
  public string Email { get; set; }

  public string? Password { get; set; }

  public string? AvatarUrl { get; set; }

  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

  public bool IsActive { get; set; } = true;

  public List<Page> CreatedPages { get; set; } = new();
  public List<Workspace_User> Workspace_Users { get; set; } = new();
}