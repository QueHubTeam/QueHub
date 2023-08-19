using FluentValidation;
using QueHub.Service.DTOs.Users;

namespace QueHub.Service.Validators.Dtos.Students;

public class UserLoginValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(dto => dto.Email).EmailAddress().WithMessage("Write correct email address");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
             .WithMessage("Password is not strong password!");
    }
}
