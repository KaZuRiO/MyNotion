using backend.Domain.Entities;

namespace backend.Domain.Repositories;

public interface IBlockRepository
{
    Task<Block?> GetBlockByIdAsync(int id);

    Task<List<Block>> GetBlocksByPageIdAsync(int pageId);

    Task<List<Block>> GetBlocksChildrenAsync(int parentBlockId);

    Task AddAsync(Block block);

    Task UpdateAsync(Block block);

    Task DeleteAsync(Block block);
}