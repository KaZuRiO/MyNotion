namespace backend.Application.UseCases;
using backend.Domain.Entities;
using backend.Domain.Repositories;

public class RoleUseCase
{
    private readonly IRoleRepository _roleRepository;

    public RoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        var roles = await _roleRepository.GetRolesAsync();
        return roles;
    }
    public async Task<Role> GetRoleByIdAsync(int id)
    {
        var role = await _roleRepository.GetRoleByIdAsync(id);
        return role;
    }
    public async Task CreateRoleAsync(Role role)
    {
        await _roleRepository.CreateRoleAsync(role);
    }
    public async Task UpdateRoleAsync(Role role)
    {
        await _roleRepository.UpdateRoleAsync(role);
    }
    public async Task DeleteRoleAsync(int id)
    {
        await _roleRepository.DeleteRoleAsync(id);
    }
}