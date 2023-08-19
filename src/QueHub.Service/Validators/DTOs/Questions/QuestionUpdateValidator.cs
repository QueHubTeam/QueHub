using FluentValidation;
using QueHub.Service.Common.Helpers;
using QueHub.Service.DTOs.Questions;

namespace QueHub.Service.Validators.DTOs.Questions;

public class QuestionUpdateValidator : AbstractValidator<QuestionUpdateDto>
{
    public QuestionUpdateValidator()
    {
        RuleFor(dto => dto.Title).NotEmpty().NotNull().WithMessage("Title name is required!")
            .MinimumLength(3).WithMessage("Title name must be more than 3 characters!")
            .MaximumLength(50).WithMessage("Title name must be less than 50 characters!");

        RuleFor(dto => dto.Content).NotEmpty().NotNull().WithMessage("Title name is required!")
            .MinimumLength(10).WithMessage("Title name must be more than 3 characters!")
            .MaximumLength(256).WithMessage("Title name must be less than 50 characters!");

        int maxImageSizeMB = 5;
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.ImagePath.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");
    }
}