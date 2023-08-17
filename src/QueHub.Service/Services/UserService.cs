using AutoMapper;
using QueHub.DAL.IRepositories;
using QueHub.Domain.Entity.User;
using QueHub.Service.DTOs.Users;
using QueHub.Service.Exceptions.Users;
using QueHub.Service.Interfaces;

namespace QueHub.Service.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<UserResultDto> CreateAsync(UserCreationDto userDto)
    {
        var existingUser = await unitOfWork.UserRepository.SelectAsync(u => u.Email == userDto.Email);
        if (existingUser is not null)
            throw new UserAlreadyExistsException();

        var newUser = mapper.Map<UserEntity>(userDto);
        await unitOfWork.UserRepository.AddAsync(newUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserResultDto>(newUser);
    }

    public async Task<UserResultDto> UpdateAsync(UserUpdateDto userDto)
    {
        var existingUser = await unitOfWork.UserRepository.SelectAsync(u => u.Id == userDto.Id);
        if (existingUser is null)
            throw new UserNotFoundException();

        mapper.Map(userDto, existingUser);
        await unitOfWork.UserRepository.UpdateAsync(existingUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserResultDto>(existingUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await unitOfWork.UserRepository.SelectAsync(u => u.Id == id);
        if (user is null)
            throw new UserNotFoundException();

        await unitOfWork.UserRepository.DeleteAsync(x => x == user);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async Task<UserResultDto> GetByIdAsync(long id)
    {
        var user = await unitOfWork.UserRepository.SelectAsync(u => u.Id == id);
        if (user is null)
            throw new UserNotFoundException();

        return mapper.Map<UserResultDto>(user);
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync()
    {
        var users = unitOfWork.UserRepository.SelectAll();
        return mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<IEnumerable<UserResultDto>> GetAllByNameAsync(string name)
    {
        var users = unitOfWork.UserRepository.SelectAll(u =>
            u.FirstName.Contains(name) || u.LastName.Contains(name));

        return mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<IEnumerable<UserResultDto>> GetAllByUsernameAsync(string username)
    {
        var users = unitOfWork.UserRepository
            .SelectAll(u => u.UserName.StartsWith(username.ToLower().Trim()));
        
        return mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<bool> CheckCredentialsAsync(string username, string password)
    {
        var user = await unitOfWork.UserRepository.SelectAsync(u => u.UserName == username);
        if (user is null) { }
            return false;

        // Implement password validation logic
    }

    public async Task<bool> ChangePasswordAsync(long userId, string currentPassword, string newPassword)
    {
        var user = await unitOfWork.UserRepository.SelectAsync(u => u.Id == userId);
        if (user is null) { }
            throw new UserNotFoundException();

        // Implement password change logic
    }

    public async Task<bool> UpdateRatingAsync(long userId, long newRating)
    {
        var user = await unitOfWork.UserRepository.SelectAsync(u => u.Id == userId);
        if (user is null)
            throw new UserNotFoundException();

        user.Rating += newRating;
        await unitOfWork.UserRepository.UpdateAsync(user);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateProfileImageAsync(long userId, string imagePath)
    {
        var user = await unitOfWork.UserRepository.SelectAsync(u => u.Id == userId);
        if (user is null)
            throw new UserNotFoundException();

        user.ImagePath = imagePath;
        await unitOfWork.UserRepository.UpdateAsync(user);
        await unitOfWork.SaveAsync();

        return true;
    }
}
