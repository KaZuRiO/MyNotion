namespace backend.Infrastructure.Repositories;
using backend.Domain.Entities;
using backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Config;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly AppDbContext _context;

    public WorkspaceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Workspace>> GetWorkspacesAsync()
    {
        return await _context.Workspaces.ToListAsync();
    }

    public async Task<Workspace> GetWorkspaceByIdAsync(int id)
    {
        return await _context.Workspaces.FindAsync(id);
    }

    public async Task CreateWorkspaceAsync(Workspace workspace)
    {
        _context.Workspaces.Add(workspace);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWorkspaceAsync(Workspace workspace)
    {
        _context.Workspaces.Update(workspace);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWorkspaceAsync(int id)
    {
        var workspace = await _context.Workspaces.FindAsync(id);
        if (workspace != null)
        {
            _context.Workspaces.Remove(workspace);
            await _context.SaveChangesAsync();
        }
    }
}