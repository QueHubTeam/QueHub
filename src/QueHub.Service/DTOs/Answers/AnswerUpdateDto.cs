namespace QueHub.Service.DTOs.Answers;

public class AnswerUpdateDto
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long QuestionId { get; set; }

    public string Content { get; set; } = string.Empty;
}