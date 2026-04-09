namespace backend.Domain.Repositories;
using backend.Domain.Entities;

public interface IWorkspaceRepository
{
    Task<IEnumerable<Workspace>> GetWorkspacesAsync();
    Task<Workspace> GetWorkspaceByIdAsync(int id);
    Task CreateWorkspaceAsync(Workspace workspace);
    Task UpdateWorkspaceAsync(Workspace workspace);
    Task DeleteWorkspaceAsync(int id);
}