namespace backend.Domain.Repositories;
using backend.Domain.Entities;
public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}