using backend.Domain.Entities;
using backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Config;

namespace backend.Infrastructure.Repositories;

public class BlockRepository : IBlockRepository
{
    private readonly AppDbContext _context;

    public BlockRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Block?> GetBlockByIdAsync(int id)
    {
        return await _context.Blocks
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Block>> GetBlocksByPageIdAsync(int pageId)
    {
        return await _context.Blocks
            .Where(b => b.PageId == pageId)
            .ToListAsync();
    }

    public async Task<List<Block>> GetBlocksChildrenAsync(int parentBlockId)
    {
        return await _context.Blocks
            .Where(b => b.ParentBlockId == parentBlockId)
            .ToListAsync();
    }

    public async Task AddAsync(Block block)
    {
        await _context.Blocks.AddAsync(block);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Block block)
    {
        _context.Blocks.Update(block);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Block block)
    {
        _context.Blocks.Remove(block);
        await _context.SaveChangesAsync();
    }
}