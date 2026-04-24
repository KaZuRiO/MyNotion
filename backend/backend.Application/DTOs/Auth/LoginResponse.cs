namespace backend.Application.DTOs.Auth;

public class LoginResponse
{
    public bool Flag { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Token { get; set; }

    public LoginResponse(bool flag, string message, string? token = null)
    {
        Flag = flag;
        Message = message;
        Token = token;
    }
}