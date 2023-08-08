
using QueHub.Domain.Entities;
using QueHub.Domain.Entity.Questions;
using QueHub.Domain.Entity.User;

namespace QueHub.Domain.Entity.QuestionLikes;

public class QuestionLikeEntity : Auditable
{
    public long QuestionId { get; set; }
    public QuestionEntity Question { get; set; }

    public long UserId { get; set; }
    public UserEntity User { get; set; }
}