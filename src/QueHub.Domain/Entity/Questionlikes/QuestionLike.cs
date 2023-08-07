
using QueHub.Domain.Entities;

namespace QueHub.Domain.Entity.Questionlikes;

public class QuestionLike : Auditable
{
    public long QuestionId { get; set; }

    public long UserId { get; set; }
}