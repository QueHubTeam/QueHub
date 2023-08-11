using QueHub.Domain.Commons;
using QueHub.Domain.Entity.Questions;
using QueHub.Domain.Entity.User;

namespace QueHub.Domain.Entity.QuestionDislikes;

public class QuestionDislikeEntity : Auditable
{
    public long QuestionId { get; set; }
    public QuestionEntity Question { get; set; }

    public long UserId { get; set; }
    public UserEntity User { get; set; }
}