using backend.Domain.Enum;

namespace backend.Application.DTOs.Block;

public class CreateBlockDto
{
    public int PageId { get; set; }
    public int? ParentBlockId { get; set; }
    public BlockType Type { get; set; }
    public decimal Position { get; set; }
    public string? Content { get; set; }
}