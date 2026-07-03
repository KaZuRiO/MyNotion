namespace backend.Domain.ValueObjects.BlockContent;

public class ImageContent : IBlockContent
{
    public string Url { get; set; } = "";
    public string? Alt { get; set; }
    public string? Caption { get; set; }
}