namespace backend.Domain.ValueObjects.BlockContent;

public class HeadingContent : IBlockContent
{
    public string Text { get; set; } = "";

    /// Level of heading (1, 2, 3 like Notion)
    public int Level { get; set; }
}
