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

    public async Task<IEnumerable<Workspace_User>> GetWorkspaceUsersAsync()
    {
        return await _context.Workspace_Users.ToListAsync();
    }

    public async Task<Workspace_User> GetWorkspaceUserByIdAsync(int id)
    {
        return await _context.Workspace_Users.FindAsync(id);
    }

    public async Task CreateWorkspaceUserAsync(Workspace_User workspace_user)
    {
        var workspaceUser = new Workspace_User
        {
            WorkspaceId = workspace_user.WorkspaceId,
            UserId = workspace_user.UserId,
            RoleId = workspace_user.RoleId
        };
        _context.Workspace_Users.Add(workspaceUser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWorkspaceUserAsync(int id, Workspace_User workspace_user)
    {
        var workspaceUser = await _context.Workspace_Users.FindAsync(id);
        if (workspaceUser != null)
        {
            _context.Workspace_Users.Update(workspaceUser);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteWorkspaceUserAsync(int id)
    {
        var workspaceUser = await _context.Workspace_Users.FindAsync(id);
        if (workspaceUser != null)
        {
            _context.Workspace_Users.Remove(workspaceUser);
            await _context.SaveChangesAsync();
        }
    }
}