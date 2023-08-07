
using QueHub.Domain.Entities;

namespace QueHub.Domain.Entity.QuestionDislikes;

public class QuestionDislike : Auditable
{
    public long QuestionId { get; set; }

    public long UserId { get; set; }
}