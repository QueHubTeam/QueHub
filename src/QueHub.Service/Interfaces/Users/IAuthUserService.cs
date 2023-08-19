using QueHub.Service.DTOs.Users;
namespace QueHub.Service.Interfaces.Persons;
public interface IAuthUserService
{
    public Task<(bool Result, int CashedMinutes)> RegisterAsync(UserCreationDto registerDto);
    public Task<(bool Result, int CashedVerificationMinutes)> SendCodeForRegisterAsync(string mail);
    public Task<(bool Result, string Token)> VerifyRegisterAsync(string mail, int code);
    public Task<(bool Result, string Token)> LoginAsync(UserLoginDto loginDto);
}
