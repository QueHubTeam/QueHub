using QueHub.Service.DTOs.Users;

namespace QueHub.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> CreateUserAsync(UserCreationDto user);

    Task<UserResultDto> UpdateUserAsync(UserUpdateDto user);

    Task<bool> DeleteUserAsync(long id);

    Task<UserResultDto> GetUserByIdAsync(long id);

    Task<IEnumerable<UserResultDto>> GetAllUsersAsync();

    Task<IEnumerable<UserResultDto>> GetAllUsersByNameAsync(string name);

    Task<IEnumerable<UserResultDto>> GetAllUsersByUsernameAsync(string name);

    Task<bool> CheckCredentialsAsync(string username, string password);

    Task<bool> ChangePasswordAsync(long userId, string currentPassword, string newPassword);

    Task<bool> UpdateUserRatingAsync(long userId, long newRating);

    Task<bool> UpdateUserProfileImageAsync(long userId, string imagePath);
}