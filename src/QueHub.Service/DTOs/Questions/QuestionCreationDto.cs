namespace QueHub.Service.DTOs.Questions;

public class QuestionCreationDto
{
    public long UserId { get; set; }

    public long CategoryId { get; set; }

    public string? ImagePath { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}