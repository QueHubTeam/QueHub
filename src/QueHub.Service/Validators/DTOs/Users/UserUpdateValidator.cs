using FluentValidation;
using QueHub.Service.Common.Helpers;
using QueHub.Service.DTOs.Users;

namespace QueHub.Service.Validators.Dtos.Students;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {

        RuleFor(dto => dto.FirstName).NotEmpty().NotNull().WithMessage("Person First_Name is required!")
            .MinimumLength(3).WithMessage("Person First_Name must be more than 3 characters!")
            .MaximumLength(50).WithMessage("Person First_Name must be less than 50 characters!");

        RuleFor(dto => dto.LastName).NotEmpty().NotNull().WithMessage("Person Last_Name is required!")
            .MinimumLength(3).WithMessage("Person Last_Name must be more than 3 characters!")
            .MaximumLength(50).WithMessage("Person Last_Name must be less than 50 characters!");
        
        RuleFor(dto => dto.UserName).NotEmpty().NotNull().WithMessage("Person User_Name is required!")
            .MinimumLength(3).WithMessage("Person User_Name must be more than 3 characters!")
            .MaximumLength(50).WithMessage("Person User_Name must be less than 50 characters!");

        When(dto => dto.ImagePath is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.ImagePath.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong!");
    }


}
