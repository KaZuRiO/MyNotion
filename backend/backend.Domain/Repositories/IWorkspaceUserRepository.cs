namespace backend.Domain.Repositories;

using backend.Domain.Entities;
public interface IWorkspaceUserRepository
{
    Task<IEnumerable<Workspace_User>> GetWorkspaceUsersAsync();
    Task<Workspace_User> GetWorkspaceUserByIdAsync(int id);
    Task CreateWorkspaceUserAsync(Workspace_User workspaceUser);
    Task UpdateWorkspaceUserAsync(int id, Workspace_User workspaceUser);
    Task DeleteWorkspaceUserAsync(int id);
}