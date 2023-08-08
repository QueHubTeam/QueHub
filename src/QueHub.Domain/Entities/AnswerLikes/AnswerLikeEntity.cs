using QueHub.Domain.Entities;
using QueHub.Domain.Entity.Answers;
using QueHub.Domain.Entity.User;

namespace QueHub.Domain.Entity.AnswerLikes;

public class AnswerLikeEntity : Auditable
{
    public long AnswerId { get; set; }
    public AnswerEntity Answer { get; set; }

    public long UserId { get; set; }
    public UserEntity User { get; set; }
}