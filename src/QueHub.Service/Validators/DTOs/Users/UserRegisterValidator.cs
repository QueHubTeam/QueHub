using FluentValidation;
using QueHub.Service.DTOs.Users;


namespace QueHub.Service.Validators.Dtos.Students;

public class UserRegisterValidator: AbstractValidator<UserCreationDto>
{
    public UserRegisterValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required!")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");
        
        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required!")
           .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.UserName).NotNull().NotEmpty().WithMessage("UserName is required!")
           .MaximumLength(30).WithMessage("Username must be less than 30 characters");

        RuleFor(dto => dto.Email).NotNull().NotEmpty().WithMessage("Email required")
            .EmailAddress().WithMessage("Write email address");
        
        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong!");
    }
}
