using backend.Domain.Entities;
using backend.Domain.Repositories;
using backend.Application.DTOs.Block;

namespace backend.Application.UseCases;

public class BlockUseCase
{
    private readonly IBlockRepository _blockRepository;

    public BlockUseCase(IBlockRepository blockRepository)
    {
        _blockRepository = blockRepository;
    }

    
    public async Task<List<BlockDto>> GetBlocksByPageId(int pageId)
    {
        var blocks = await _blockRepository.GetBlocksByPageIdAsync(pageId);
        return blocks.Select(block => new BlockDto
        {
            Id = block.Id,
            PageId = block.PageId,
            Type = block.Type,
            Content = block.Content,
            Position = block.Position,
            ParentBlockId = block.ParentBlockId
        }).ToList();
    }

    public async Task<BlockDto?> GetBlockById(int id)
    {
        var block = await _blockRepository.GetBlockByIdAsync(id);
        if (block == null) return null;
        return new BlockDto
        {
            Id = block.Id,
            PageId = block.PageId,
            Type = block.Type,
            Content = block.Content,
            Position = block.Position,
            ParentBlockId = block.ParentBlockId
        };
    }

   
    public async Task<BlockDto> CreateBlockAsync(CreateBlockDto dto)
    {
        var block = new Block(
            dto.PageId,
            dto.Type,
            dto.Position,
            dto.Content ?? "",
            dto.ParentBlockId
        );

        await _blockRepository.AddAsync(block);

        return new BlockDto
        {
            Id = block.Id,
            PageId = block.PageId,
            Type = block.Type,
            Content = block.Content,
            Position = block.Position,
            ParentBlockId = block.ParentBlockId
        };
    }
    public async Task<BlockDto?> UpdateBlockAsync(int id, UpdateBlockDto dto)
    {
        var block = await _blockRepository.GetBlockByIdAsync(id);
        if (block == null) return null;

        block.Type = dto.Type;
        block.Position = dto.Position;
        block.Content = dto.Content ?? "";
        block.ParentBlockId = dto.ParentBlockId;

        await _blockRepository.UpdateAsync(block);

        return new BlockDto
        {
            Id = block.Id,
            PageId = block.PageId,
            Type = block.Type,
            Content = block.Content,
            Position = block.Position,
            ParentBlockId = block.ParentBlockId
        };
    }

    
    public async Task DeleteBlockAsync(int id)
    {
        var block = await _blockRepository.GetBlockByIdAsync(id);
        if (block == null) return;

        await _blockRepository.DeleteAsync(block);
    }

   
    public async Task<List<BlockDto>> GetChildrenAsync(int parentBlockId)
    {
        var blocks = await _blockRepository.GetBlocksChildrenAsync(parentBlockId);
        return blocks.Select(block => new BlockDto
        {
            Id = block.Id,
            PageId = block.PageId,
            Type = block.Type,
            Content = block.Content,
            Position = block.Position,
            ParentBlockId = block.ParentBlockId
        }).ToList();
    }

}
