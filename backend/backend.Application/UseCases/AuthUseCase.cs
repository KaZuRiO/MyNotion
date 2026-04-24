namespace backend.Application.UseCases;

using backend.Application.Services;
using backend.Application.DTOs.Auth;

public class AuthUseCase
{
    private readonly IAuthRepository _authRepository;

    public AuthUseCase(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public Task<LoginResponse> LoginUserAsync(LoginUserDto dto)
    {
        return _authRepository.LoginUserAsync(dto);
    }

    public Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto dto)
    {
        return _authRepository.RegisterUserAsync(dto);
    }
}