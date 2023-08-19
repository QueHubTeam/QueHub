using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace QueHub.Service.DTOs.Users;

public class UserUpdateDto
{
    public int Id { get; set; }

    [MaxLength(25)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(25)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(25)]
    public string UserName { get; set; } = string.Empty;

    public IFormFile ImagePath { get; set; } = default!;

    public string Password { get; set; } = string.Empty;
}