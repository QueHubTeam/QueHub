using QueHub.Domain.Commons;
using QueHub.Domain.Entity.Questions;
using QueHub.Domain.Entity.User;

namespace QueHub.Domain.Entity.Answers;

public class AnswerEntity : Auditable
{
    public long UserId { get; set; }
    public UserEntity User { get; set; }

    public long QuestionId { get; set; }
    public QuestionEntity Question { get; set; }

    public string Content { get; set; } = string.Empty;
}