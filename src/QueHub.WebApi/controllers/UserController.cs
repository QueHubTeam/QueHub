using Microsoft.AspNetCore.Mvc;
using QueHub.Service.DTOs.Users;
using QueHub.Service.Interfaces;
using QueHub.WebApi.controllers;

namespace QueHub.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IQuestionService _questionService;

    public UserController(IUserService userService, IQuestionService questionService)
    {
        _userService = userService;
        _questionService = questionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(UserCreationDto user)
    {
        var createdUser = await _userService.CreateAsync(user);
        return Ok(createdUser);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser(UserUpdateDto user)
    {
        var updatedUser = await _userService.UpdateAsync(user);
        return Ok(updatedUser);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("getbyname/{name}")]
    public async Task<IActionResult> GetUsersByName(string name)
    {
        var users = await _userService.GetAllByNameAsync(name);
        return Ok(users);
    }

    [HttpGet("getbyusername/{username}")]
    public async Task<IActionResult> GetUsersByUsername(string username)
    {
        var users = await _userService.GetAllByUsernameAsync(username);
        return Ok(users);
    }

    [HttpGet("checkcredentials")]
    public async Task<IActionResult> CheckCredentials(string username, string password)
    {
        var isValid = await _userService.CheckCredentialsAsync(username, password);
        return Ok(isValid);
    }

    [HttpPost("changepassword")]
    public async Task<IActionResult> ChangePassword(long userId, string currentPassword, string newPassword)
    {
        var result = await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);
        return Ok(result);
    }

    [HttpGet("getuserprofileimage/{userId}")]
    public async Task<IActionResult> GetUserProfileImage(long userId)
    {
        var imagePath = await _userService.GetProfileImageAsync(userId);
        return Ok(imagePath);
    }

    [HttpGet("getquestionsbyuser/{userId}")]
    public async Task<IActionResult> GetQuestionsByUserId(long userId)
    {
        var questions = await _questionService.GetByUserIdAsync(userId);
        return Ok(questions);
    }
}
