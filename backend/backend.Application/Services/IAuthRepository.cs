namespace backend.Application.Services;
using backend.Application.DTOs.Auth;
public interface IAuthRepository
{
  Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto registerUserDto);
  Task<LoginResponse> LoginUserAsync(LoginUserDto loginUserDto);
}
