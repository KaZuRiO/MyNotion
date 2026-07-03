namespace backend.Application.DTOs.Block;
using backend.Domain.Entities;
using backend.Domain.Enum;

public class MoveBlockDto
{
    public int BlockId { get; set; }

    public int? NewParentBlockId { get; set; }

    public decimal NewPosition { get; set; }
}
