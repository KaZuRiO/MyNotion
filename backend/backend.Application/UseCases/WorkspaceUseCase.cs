namespace backend.Application.UseCases;

using backend.Application.DTOs.Workspace;
using backend.Domain.Entities;
using backend.Domain.Repositories;

public class WorkspaceUseCase
{
    private readonly IWorkspaceRepository _workspaceRepository;

    public WorkspaceUseCase(IWorkspaceRepository workspaceRepository)
    {
        _workspaceRepository = workspaceRepository;
    }

    public async Task<IEnumerable<WorkspaceDto>> GetWorkspacesAsync()
    {
        var workspaces = await _workspaceRepository.GetWorkspacesAsync();
        return workspaces.Select(workspace => new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Description = workspace.Description,
            UserId = workspace.UserId,
            CreatedAt = workspace.CreatedAt,
            UpdatedAt = workspace.UpdatedAt
        });
    }
    public async Task<WorkspaceDto?> GetWorkspaceByIdAsync(int id)
    {
        var workspace = await _workspaceRepository.GetWorkspaceByIdAsync(id);
        if (workspace == null) return null;
        return new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Description = workspace.Description,
            UserId = workspace.UserId,
            CreatedAt = workspace.CreatedAt,
            UpdatedAt = workspace.UpdatedAt
        };
    }

    public async Task<WorkspaceDto> CreateWorkspaceAsync(CreateWorkspaceDto createWorkspaceDto)
    {
        var workspace = new Workspace
        {
            Name = createWorkspaceDto.Name,
            Description = createWorkspaceDto.Description,
            UserId = createWorkspaceDto.UserId,
            CreatedAt = DateTime.UtcNow
        };

        await _workspaceRepository.CreateWorkspaceAsync(workspace);
        return new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Description = workspace.Description,
            UserId = workspace.UserId,
            CreatedAt = workspace.CreatedAt,
            UpdatedAt = workspace.UpdatedAt
        };
    }

    public async Task<WorkspaceDto?> UpdateWorkspaceAsync(int id, UpdateWorkspaceDto updateWorkspaceDto)
    {
        var workspace = await _workspaceRepository.GetWorkspaceByIdAsync(id);
        if (workspace == null) return null;
        workspace.Name = updateWorkspaceDto.Name;
        workspace.Description = updateWorkspaceDto.Description;
        workspace.UpdatedAt = DateTime.UtcNow;

        await _workspaceRepository.UpdateWorkspaceAsync(workspace);
        return new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Description = workspace.Description,
            UserId = workspace.UserId,
            CreatedAt = workspace.CreatedAt,
            UpdatedAt = workspace.UpdatedAt
        };
    }

    public async Task DeleteWorkspaceAsync(int id)
    {
        await _workspaceRepository.DeleteWorkspaceAsync(id);
    }

}
