namespace backend.Domain.Entities;
using backend.Domain.Enum;
public class Block
{
    public int Id { get; set; }
    public int PageId { get; set; }
    public BlockType Type { get; set; }
    public decimal Position { get; set; }
    public string Content { get; set; } = string.Empty;
    public int? ParentBlockId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Block() { }
}