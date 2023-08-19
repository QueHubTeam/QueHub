namespace QueHub.Service.DTOs.Security;

public class UserVerificationDto
{
    public int Code { get; set; }

    public int Attempt { get; set; }

    public DateTime CreatedAt { get; set; }
}
