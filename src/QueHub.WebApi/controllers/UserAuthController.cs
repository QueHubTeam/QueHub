using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueHub.Service.DTOs.Users;
using QueHub.Service.Interfaces.Persons;
using QueHub.Service.Validators.Dtos.Students;

namespace GameMasterArena.Api.Controller;

[Route("api/StudentAuth")]
[ApiController]
public class UserAuthController : ControllerBase
{
    private readonly IAuthUserService _authService;

    public UserAuthController(IAuthUserService auth)
    {
        this._authService = auth;
    }


    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromForm] UserCreationDto registerDto)
    {
        var validator = new UserRegisterValidator();
        var result = validator.Validate(registerDto);
        if (result.IsValid)
        {
            var serviceResult = await _authService.RegisterAsync(registerDto);
            return Ok(new { serviceResult.Result, serviceResult.CashedMinutes });
        }
        else return BadRequest(result.Errors);
    }


    [HttpPost("register/send-code")]
    [AllowAnonymous]
    public async Task<IActionResult> SendCodeRegisterAsync(string mail)
    {
        var serviceResult = await _authService.SendCodeForRegisterAsync(mail);
        return Ok(new { serviceResult.Result, serviceResult.CashedVerificationMinutes });
    }


    [HttpPost("register/verify")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] UserVerifyDto verifyDto)
    {
        var servisResult = await _authService.VerifyRegisterAsync(verifyDto.Email, verifyDto.Code);
        return Ok(new { servisResult.Result, servisResult.Token });
    }


    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto logindto)
    {
        var validator = new UserLoginValidator();
        var valResult = validator.Validate(logindto);
        if (valResult.IsValid == false) return BadRequest(valResult.Errors);

        var serviceResult = await _authService.LoginAsync(logindto);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }
}
