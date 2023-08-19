using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using QueHub.Domain.Entity.User;
using QueHub.Service.Common.Helpers;
using QueHub.Service.Common.Security;
using QueHub.Service.Dtos.PersonsAuth;
using QueHub.Service.DTOs.Users;
using QueHub.Service.Exceptions.Auth;
using QueHub.Service.Exceptions.Users;
using QueHub.Service.Interfaces.Common;
using QueHub.Service.Interfaces.Notifications;
using QueHub.Service.Interfaces.Persons;

namespace QueHub.Service.Services.Students;

public class AuthUserService : IAuthUserService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepasitory _personRepository;
    private readonly IMailSender _mailSender;
    private readonly ITokenUserService _tokenPersonService;
    private readonly IFileService _fileService;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    public AuthUserService(IMemoryCache memoryCache,
        IPerson personRepository,
        IMailSender mailSender,
        ITokenUserService tokenPersonService,
        IFileService fileService)
    {
        this._memoryCache = memoryCache;
        this._personRepository = personRepository;
        this._mailSender = mailSender;
        this._tokenPersonService = tokenPersonService;
        this._fileService = fileService;
    }



#pragma warning disable
    public async Task<(bool Result, int CashedMinutes)> RegisterAsync(UserCreationDto registerDto)
    {
        var student = await _personRepository.GetByEmailAsync(registerDto.Email);
        if (student is not null) throw new UserAlreadyExistsException(registerDto.Email);

        // delete if exists user by this phone number
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + registerDto.Email, out UserCreationDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(REGISTER_CACHE_KEY + registerDto.Email);
        }
        else _memoryCache.Set(REGISTER_CACHE_KEY + registerDto.Email, registerDto,
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public async Task<(bool Result, int CashedVerificationMinutes)> SendCodeForRegisterAsync(string mail)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + mail, out UserCreationDto registerDto))
        {
            UserVerificationDto verificationDto = new UserVerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();

            verificationDto.Code = CodeGenerator.GenerateRandomNumber();

            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + mail, out UserVerificationDto oldDto))
            {
                _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + mail);
            }
            _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + mail, verificationDto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            EmailMessage emailSms = new EmailMessage();
            emailSms.Title = "Game Master Arena";
            emailSms.Content = "Verification code : " + verificationDto.Code;
            emailSms.Recipent = mail;

            var mailResult = await _mailSender.SendAsync(emailSms);
            if (mailResult is true) return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
            else return (Result: false, CachedVerificationMinutes: 0);
        }
        else throw new UserCacheDataExpiredException();
    }


    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string mail, int code)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + mail, out PersonRegisterDto registroDto))
        {
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + mail, out PersonVerificationDto verificationDto))
            {
                if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new VerificationTooManyRequestsException();
                else if (verificationDto.Code == code)
                {
                    var dbResult = await RegisterToDatabaseAsync(registroDto);
                    if (dbResult is true)
                    {
                        var student = await _personRepository.GetByEmailAsync(mail);
                        string token = _tokenPersonService.GenerateToken(student);
                        return (Result: true, Token: token);
                    }
                    else return (Result: false, Token: "");
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + mail);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + mail, verificationDto,
                        TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));
                    return (Result: false, Token: "");
                }
            }
            else throw new VerificationCodeExpiredException();
        }
        else throw new UserCacheDataExpiredException();
    }

    private async Task<bool> RegisterToDatabaseAsync(UserCreationDto registroDto)
    {

        var person = new UserEntity();
        person.FirstName = registroDto.FirstName;
        person.LastName = registroDto.LastName;
        person.UserName = registroDto.UserName;
        person.Email = registroDto.Email;

        var hasherResult = PasswordHasher.Hash(registroDto.Password);
        person.Password = hasherResult.Hash;
        person.Salt = hasherResult.Salt;

        person.CreateAt = person.UpdateAt = TimeHelper.GetDateTime();

        var dbResult = await _personRepository.CreateAsync(person);
        return dbResult > 0;
    }

    public async Task<(bool Result, string Token)> LoginAsync(UserLoginDto loginDto)
    {
        var student = await _personRepository.GetByEmailAsync(loginDto.Email);
        if (student is null) throw new UserNotFoundException();

        var hasherResult = PasswordHasher.Verify(loginDto.Password, student.Password, student.Salt);
        if (hasherResult == false) throw new PasswordNotMatchException();

        string token = _tokenPersonService.GenerateToken(student);

        return (Result: true, Token: token);
    }



}
