namespace QueHub.Service.DTOs.Users;

public class UserVerifyDto
{
    public string Email { get; set; } = string.Empty;

    public int Code { get; set; }
}
