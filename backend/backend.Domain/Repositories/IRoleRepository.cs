namespace backend.Domain.Repositories;
using backend.Domain.Entities;
public interface IRoleRepository
{
  Task<IEnumerable<Role>> GetRolesAsync();
  Task<Role> GetRoleByIdAsync(int id);
  Task CreateRoleAsync(Role role);
  Task UpdateRoleAsync(Role role);
  Task DeleteRoleAsync(int id);
}