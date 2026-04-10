namespace backend.Domain.Repositories;

using backend.Domain.Entities;
public interface IWorkspaceUserRepository
{
    Task<IEnumerable<WorkspaceUser>> GetWorkspaceUsersAsync();
    Task<WorkspaceUser> GetWorkspaceUserByIdAsync(int id);
    Task CreateWorkspaceUserAsync(WorkspaceUser workspaceUser);
    Task UpdateWorkspaceUserAsync(int id, WorkspaceUser workspaceUser);
    Task DeleteWorkspaceUserAsync(int id);
}