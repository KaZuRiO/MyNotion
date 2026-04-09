namespace backend.Application.DTOs.Page;

using Microsoft.EntityFrameworkCore.Metadata;


public class CreatePageDto
{
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string? Icon { get; set; } = null;
}