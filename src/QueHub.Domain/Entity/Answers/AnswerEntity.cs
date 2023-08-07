using QueHub.Domain.Entities;

namespace QueHub.Domain.Entity.Answers;

public class AnswerEntity : Auditable
{
    public long UserId { get; set; }

    public long QuestionId { get; set; }

    public string Content { get; set; } = string.Empty;
}