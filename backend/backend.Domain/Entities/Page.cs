namespace backend.Domain.Entities
{
  public class Page

  {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public string? Icon { get; set; }
  }

}