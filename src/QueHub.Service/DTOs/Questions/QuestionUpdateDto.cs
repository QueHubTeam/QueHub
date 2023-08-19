using Microsoft.AspNetCore.Http;
namespace QueHub.Service.DTOs.Questions;

public class QuestionUpdateDto
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long CategoryId { get; set; }

    public IFormFile ImagePath { get; set; } = default!;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}