using QueHub.Service.DTOs.Categories;
using QueHub.Service.DTOs.Users;

namespace QueHub.Service.DTOs.Questions;

public class QuestionResultDto
{
    public long Id { get; set; }

    public UserResultDto User { get; set; }

    public CategoryResultDto Category { get; set; }

    public string? ImagePath { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}