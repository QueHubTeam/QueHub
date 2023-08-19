using QueHub.Service.DTOs.Users;

namespace QueHub.Service.Interfaces.Persons;

public interface IUserService
{


    public Task<IList<UserResultDto>> GetAllAsync();

    public Task<UserResultDto> GetByIdAsync(long teamId);

    public Task<bool> UpdateAsync(UserUpdateDto dto);

    public Task<long> CountAsync();
}
