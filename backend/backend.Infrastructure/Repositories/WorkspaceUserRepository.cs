namespace backend.Infrastructure.Repositories;

using backend.Domain.Entities;
using backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Config;

public class WorkspaceUserRepository : IWorkspaceUserRepository
{
    private readonly AppDbContext _context;

    public WorkspaceUserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkspaceUser>> GetWorkspaceUsersAsync()
    {
        return await _context.WorkspaceUsers.ToListAsync();
    }

    public async Task<WorkspaceUser> GetWorkspaceUserByIdAsync(int id)
    {
        return await _context.WorkspaceUsers.FindAsync(id);
    }

    public async Task CreateWorkspaceUserAsync(WorkspaceUser WorkspaceUser)
    {
        var workspaceUser = new WorkspaceUser
        {
            WorkspaceId = WorkspaceUser.WorkspaceId,
            UserId = WorkspaceUser.UserId,
            RoleId = WorkspaceUser.RoleId
        };
        _context.WorkspaceUsers.Add(workspaceUser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWorkspaceUserAsync(int id, WorkspaceUser WorkspaceUser)
    {
        var workspaceUser = await _context.WorkspaceUsers.FindAsync(id);
        if (workspaceUser != null)
        {
            _context.WorkspaceUsers.Update(workspaceUser);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteWorkspaceUserAsync(int id)
    {
        var workspaceUser = await _context.WorkspaceUsers.FindAsync(id);
        if (workspaceUser != null)
        {
            _context.WorkspaceUsers.Remove(workspaceUser);
            await _context.SaveChangesAsync();
        }
    }
}