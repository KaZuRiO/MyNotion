namespace backend.Application.DTOs.Auth;

public class RegistrationResponse
{
    public bool Flag { get; set; }
    public string Message { get; set; } = string.Empty;

    public RegistrationResponse(bool flag, string message)
    {
        Flag = flag;
        Message = message;
    }
}