namespace backend.Domain.Entities;
using backend.Domain.Enum;
public class Block
{
    public int Id { get; private set; }
    public int PageId { get; private set; }
    public BlockType Type { get; set; }
    public decimal Position { get; set; }
    public string Content { get; set; } = string.Empty;
    public int? ParentBlockId { get; set; }

    private Block() { } // 👈 EF ONLY

    public Block(int id, int pageId, BlockType type, decimal position, string content, int? parentBlockId)
    {
        Id = id;
        PageId = pageId;
        Type = type;
        Position = position;
        Content = content;
        ParentBlockId = parentBlockId;
    }

    public Block(int pageId, BlockType type, decimal position, string content, int? parentBlockId)
    {
        PageId = pageId;
        Type = type;
        Position = position;
        Content = content;
        ParentBlockId = parentBlockId;
    }
}
