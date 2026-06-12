namespace backend.Application.DTOs.Block;
using backend.Domain.Entities;
using backend.Domain.Enum;

public class BlockDto{
    public int Id { get; set; }
    public int PageId { get; set; }
    public int? ParentBlockId { get; set; }
    public BlockType Type { get; set; }
    public string? Content { get; set; }
    public decimal Position { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
