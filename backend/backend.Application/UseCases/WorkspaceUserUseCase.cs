namespace backend.Application.UseCases;
using backend.Domain.Entities;
using backend.Domain.Repositories;

public class WorkspaceUserUseCase
{
    private readonly IWorkspaceUserRepository _workspaceUserRepository;

    public WorkspaceUserUseCase(IWorkspaceUserRepository workspaceUserRepository)
    {
        _workspaceUserRepository = workspaceUserRepository;
    }

    public async Task<IEnumerable<Workspace_User>> GetWorkspaceUsersAsync()
    {
        return await _workspaceUserRepository.GetWorkspaceUsersAsync();
    }
    public async Task<Workspace_User> GetWorkspaceUserByIdAsync(int id)
    {
        return await _workspaceUserRepository.GetWorkspaceUserByIdAsync(id);
    }

  public async Task<Workspace_User> CreateWorkspaceUserAsync(Workspace workspace, User user, Role role)
  {
      var workspaceUser = new Workspace_User
      {
          WorkspaceId = workspace.Id,
          UserId = user.Id,
          Role = role,
        //   CreatedAt = DateTime.UtcNow,
        //   UpdatedAt = DateTime.UtcNow
      };

      await _workspaceUserRepository.CreateWorkspaceUserAsync(workspace, user, role);
      return workspaceUser;
  }

  public async Task UpdateWorkspaceUserAsync(int id, Workspace workspace, User user, Role role)
    {
        var workspaceUser = await _workspaceUserRepository.GetWorkspaceUserByIdAsync(id);
        workspaceUser.Workspace = workspace;
        workspaceUser.User = user;
        workspaceUser.Role = role;
        workspaceUser.UpdatedAt = DateTime.UtcNow;

        await _workspaceUserRepository.UpdateWorkspaceUserAsync(id, workspace, user, role);
    }

    public async Task DeleteWorkspaceUserAsync(int id)
    {
        var workspaceUser = await _workspaceUserRepository.GetWorkspaceUserByIdAsync(id);
        await _workspaceUserRepository.DeleteWorkspaceUserAsync(id);
    }

}