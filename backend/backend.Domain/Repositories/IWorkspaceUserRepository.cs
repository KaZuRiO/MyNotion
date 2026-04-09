namespace backend.Domain.Repositories;
using backend.Domain.Entities;
public interface IWorkspaceUserRepository
{
    Task<IEnumerable<Workspace_User>> GetWorkspaceUsersAsync();
    Task<Workspace_User> GetWorkspaceUserByIdAsync(int id);
    Task CreateWorkspaceUserAsync(Workspace workspace, User user, Role role);
    Task UpdateWorkspaceUserAsync(int id, Workspace workspace, User user, Role role);
    Task DeleteWorkspaceUserAsync(int id);
}