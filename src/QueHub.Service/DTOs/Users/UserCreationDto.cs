using System.ComponentModel.DataAnnotations;

namespace QueHub.Service.DTOs.Users;

public class UserCreationDto
{
    [MaxLength(25)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(25)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(25)]
    public string UserName { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}