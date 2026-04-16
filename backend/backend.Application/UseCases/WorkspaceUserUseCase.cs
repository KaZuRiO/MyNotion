namespace backend.Application.UseCases;

using backend.Domain.Entities;
using backend.Domain.Repositories;
using backend.Application.DTOs.WorkspaceUser;

public class WorkspaceUserUseCase
{
    private readonly IWorkspaceUserRepository _workspaceUserRepository;

    public WorkspaceUserUseCase(IWorkspaceUserRepository workspaceUserRepository)
    {
        _workspaceUserRepository = workspaceUserRepository;
    }

    public async Task<IEnumerable<WorkspaceUserDto>> GetWorkspaceUsersAsync()
    {
        var workspaceUsers = await _workspaceUserRepository.GetWorkspaceUsersAsync();
        return workspaceUsers.Select(wu => new WorkspaceUserDto
        {
            Id = wu.Id,
            WorkspaceId = wu.WorkspaceId,
            UserId = wu.UserId,
            RoleId = wu.RoleId,
            CreatedAt = wu.CreatedAt,
            UpdatedAt = wu.UpdatedAt
        });
    }
    public async Task<WorkspaceUserDto> GetWorkspaceUserByIdAsync(int id)
    {
        var workspaceUser = await _workspaceUserRepository.GetWorkspaceUserByIdAsync(id);
        return new WorkspaceUserDto
        {
            Id = workspaceUser.Id,
            WorkspaceId = workspaceUser.WorkspaceId,
            UserId = workspaceUser.UserId,
            RoleId = workspaceUser.RoleId,
            CreatedAt = workspaceUser.CreatedAt,
            UpdatedAt = workspaceUser.UpdatedAt
        };
    }

    public async Task<WorkspaceUserDto> CreateWorkspaceUserAsync(CreateWorkspaceUserDto WorkspaceUser)
    {
        var workspaceUser = new WorkspaceUser
        {
            WorkspaceId = WorkspaceUser.WorkspaceId,
            UserId = WorkspaceUser.UserId,
            RoleId = WorkspaceUser.RoleId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _workspaceUserRepository.CreateWorkspaceUserAsync(workspaceUser);
        return new WorkspaceUserDto
        {
            Id = workspaceUser.Id,
            WorkspaceId = workspaceUser.WorkspaceId,
            UserId = workspaceUser.UserId,
            RoleId = workspaceUser.RoleId,
            CreatedAt = workspaceUser.CreatedAt,
            UpdatedAt = workspaceUser.UpdatedAt
        };
    }

    public async Task<WorkspaceUserDto?> UpdateWorkspaceUserAsync(int id, UpdateWorkspaceUserDto updateWorkspaceUserDto)
    {
        var workspaceUser = await _workspaceUserRepository.GetWorkspaceUserByIdAsync(id);
        if (workspaceUser == null) return null;
        workspaceUser.WorkspaceId = updateWorkspaceUserDto.WorkspaceId;
        workspaceUser.UserId = updateWorkspaceUserDto.UserId;
        workspaceUser.RoleId = updateWorkspaceUserDto.RoleId;
        workspaceUser.UpdatedAt = DateTime.UtcNow;

        await _workspaceUserRepository.UpdateWorkspaceUserAsync(workspaceUser);
        return new WorkspaceUserDto
        {
            Id = workspaceUser.Id,
            WorkspaceId = workspaceUser.WorkspaceId,
            UserId = workspaceUser.UserId,
            RoleId = workspaceUser.RoleId,
            CreatedAt = workspaceUser.CreatedAt,
            UpdatedAt = workspaceUser.UpdatedAt
        };
    }

    public async Task DeleteWorkspaceUserAsync(int id)
    {
        await _workspaceUserRepository.DeleteWorkspaceUserAsync(id);
    }

}