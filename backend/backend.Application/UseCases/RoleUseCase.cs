namespace backend.Application.UseCases;

using backend.Application.DTOs.Role;
using backend.Domain.Repositories;
using backend.Domain.Entities;


public class RoleUseCase
{
    private readonly IRoleRepository _roleRepository;

    public RoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<RoleDto>> GetRolesAsync()
    {
        var roles = await _roleRepository.GetRolesAsync();
        return roles.Select(role => new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Priority = role.Priority
        });
    }
    public async Task<RoleDto> GetRoleByIdAsync(int id)
    {
        var role = await _roleRepository.GetRoleByIdAsync(id);
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Priority = role.Priority
        };
    }
    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto dto)
    {
        var role = new Role
        {
            Name = dto.Name,
        };
        await _roleRepository.CreateRoleAsync(role);
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Priority = role.Priority
        };
    }
    public async Task<RoleDto?> UpdateRoleAsync(int id, UpdateRoleDto dto)
    {
        var role = await _roleRepository.GetRoleByIdAsync(id);
        if (role == null) return null;
        role.Name = dto.Name;
        await _roleRepository.UpdateRoleAsync(role);
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Priority = role.Priority
        };
    }
    public async Task DeleteRoleAsync(int id)
    {
        await _roleRepository.DeleteRoleAsync(id);
    }
}