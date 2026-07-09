namespace backend.Domain.ValueObjects.BlockContent;

public class TodoContent : IBlockContent
{
    public string Text { get; set; } = string.Empty;
    public bool Checked { get; set; }
}