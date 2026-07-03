namespace backend.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
  public int Id { get; set; }

  public string Username { get; set; } = string.Empty;
  public string Firstname { get; set; } = string.Empty;
  public string Lastname { get; set; } = string.Empty;
  [EmailAddress]
  public string Email { get; set; } = string.Empty;

  public string? Password { get; set; }

  public string? AvatarUrl { get; set; }

  public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

  public bool IsActive { get; set; } = true;

  public List<Page> CreatedPages { get; set; } = new();
  public List<WorkspaceUser> WorkspaceUsers { get; set; } = new();
}