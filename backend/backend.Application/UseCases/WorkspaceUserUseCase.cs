namespace backend.Application.UseCases;
using backend.Domain.Entities;
using backend.Domain.Repositories;
using backend.Application.DTOs.Workspace_User;

public class WorkspaceUserUseCase
{
    private readonly IWorkspaceUserRepository _workspaceUserRepository;

    public WorkspaceUserUseCase(IWorkspaceUserRepository workspaceUserRepository)
    {
        _workspaceUserRepository = workspaceUserRepository;
    }

    public async Task<IEnumerable<Workspace_UserDto>> GetWorkspaceUsersAsync()
    {
        var workspaceUsers = await _workspaceUserRepository.GetWorkspaceUsersAsync();
        return workspaceUsers.Select(wu => new Workspace_UserDto
        {
            Id = wu.Id,
            WorkspaceId = wu.WorkspaceId,
            UserId = wu.UserId,
            RoleId = wu.RoleId,
            CreatedAt = wu.CreatedAt,
            UpdatedAt = wu.UpdatedAt
        });
    }
    public async Task<Workspace_UserDto> GetWorkspaceUserByIdAsync(int id)
    {
        var workspaceUser = await _workspaceUserRepository.GetWorkspaceUserByIdAsync(id);
        return new Workspace_UserDto
        {
            Id = workspaceUser.Id,
            WorkspaceId = workspaceUser.WorkspaceId,
            UserId = workspaceUser.UserId,
            RoleId = workspaceUser.RoleId,
            CreatedAt = workspaceUser.CreatedAt,
            UpdatedAt = workspaceUser.UpdatedAt
        };
    }

  public async Task<Workspace_UserDto> CreateWorkspaceUserAsync(CreateWorkspace_UserDto workspace_user, Workspace workspace, User user)
  {
      var workspaceUser = new Workspace_User
      {
          WorkspaceId = workspace_user.WorkspaceId,
          UserId = workspace_user.UserId,
          RoleId = workspace_user.RoleId,
          CreatedAt = DateTime.UtcNow,
          UpdatedAt = DateTime.UtcNow
      };

      await _workspaceUserRepository.CreateWorkspaceUserAsync(workspaceUser);
      return new Workspace_UserDto
      {
          Id = workspaceUser.Id,
          WorkspaceId = workspaceUser.WorkspaceId,
          UserId = workspaceUser.UserId,
          RoleId = workspaceUser.RoleId,
          CreatedAt = workspaceUser.CreatedAt,
          UpdatedAt = workspaceUser.UpdatedAt
      };
  }

  public async Task<Workspace_UserDto?> UpdateWorkspaceUserAsync(int id, Workspace_User workspace_user)
    {
        var workspaceUser = await _workspaceUserRepository.GetWorkspaceUserByIdAsync(id);
        if (workspaceUser == null) return null;
        workspaceUser.WorkspaceId = workspace_user.WorkspaceId;
        workspaceUser.UserId = workspace_user.UserId;
        workspaceUser.RoleId = workspace_user.RoleId;
        workspaceUser.UpdatedAt = DateTime.UtcNow;

        await _workspaceUserRepository.UpdateWorkspaceUserAsync(id, workspace_user);
        return new Workspace_UserDto
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