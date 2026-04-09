namespace backend.Application.UseCases;
using backend.Domain.Entities;
using backend.Domain.Repositories;

public class WorkspaceUseCase
{
    private readonly IWorkspaceRepository _workspaceRepository;

    public WorkspaceUseCase(IWorkspaceRepository workspaceRepository)
    {
        _workspaceRepository = workspaceRepository;
    }

    public async Task<IEnumerable<Workspace>> GetWorkspacesAsync()
    {
        return await _workspaceRepository.GetWorkspacesAsync();
    }
    public async Task<Workspace> GetWorkspaceByIdAsync(int id)
    {
        return await _workspaceRepository.GetWorkspaceByIdAsync(id);
    }

    public async Task<Workspace> CreateWorkspaceAsync(string name, string description)
    {
        var workspace = new Workspace
        {
            Name = name,
            Description = description,
            CreatedAt = DateTime.UtcNow
        };

        await _workspaceRepository.CreateWorkspaceAsync(workspace);
        return workspace;
    }

    public async Task UpdateWorkspaceAsync(int id, string name, string description)
    {
        var workspace = await _workspaceRepository.GetWorkspaceByIdAsync(id);
        workspace.Name = name;
        workspace.Description = description;
        workspace.UpdatedAt = DateTime.UtcNow;

        await _workspaceRepository.UpdateWorkspaceAsync(workspace);
    }

    public async Task DeleteWorkspaceAsync(int id)
    {
        var workspace = await _workspaceRepository.GetWorkspaceByIdAsync(id);
        await _workspaceRepository.DeleteWorkspaceAsync(id);
    }

}
