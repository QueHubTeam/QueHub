using QueHub.Service.DTOs.Questions;
using QueHub.Service.DTOs.Users;

namespace QueHub.Service.DTOs.Answers;

public class AnswerResultDto
{
    public long Id { get; set; }

    public UserResultDto User { get; set; }

    public QuestionResultDto Question { get; set; }

    public string Content { get; set; } = string.Empty;
}