using QueHub.Domain.Entities;
namespace QueHub.Domain.Entity.AnswerDislikes;

public class AnswerDislikeEntity : Auditable
{
    public long AnswerId { get; set; }

    public long UserId { get; set;}

}