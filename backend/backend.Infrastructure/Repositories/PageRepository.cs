namespace backend.Infrastructure.Repositories;

using backend.Domain.Entities;
using backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Config;
public class PageRepository : IPageRepository
{
    private readonly AppDbContext _context;

    public PageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Page>> GetPagesAsync()
    {
        return await _context.Pages.ToListAsync();
    }

    public async Task<Page?> GetPageByIdAsync(int id)
    {
        return await _context.Pages.FindAsync(id);
    }

    public async Task CreatePageAsync(Page page)
    {
        _context.Pages.Add(page);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePageAsync(Page page)
    {
        _context.Pages.Update(page);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePageAsync(int id)
    {
        var page = await _context.Pages.FindAsync(id);
        if (page != null)
        {
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
        }
    }
}
