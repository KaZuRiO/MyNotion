namespace backend.Domain.ValueObjects.BlockContent;

public sealed class CodeContent : IBlockContent
{
    public string Code { get; set; } = "";
    public string? Language { get; set; }
}