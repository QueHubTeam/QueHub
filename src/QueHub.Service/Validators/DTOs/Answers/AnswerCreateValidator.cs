using FluentValidation;
using QueHub.Service.DTOs.Answers;

namespace QueHub.Service.Validators.DTOs.Answers;

public class AnswerCreateValidator : AbstractValidator<AnswerCreationDto>
{
    public AnswerCreateValidator()
    {
        RuleFor(dto => dto.Content).NotEmpty().NotNull().WithMessage("Title name is required!")
            .MinimumLength(10).WithMessage("Title name must be more than 3 characters!")
            .MaximumLength(256).WithMessage("Title name must be less than 50 characters!");
    }
}