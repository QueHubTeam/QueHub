namespace QueHub.Domain.Exceptions.AnswerDislikes;

public class AnswerDislikeNotFoundException : NotFoundException
{
    public AnswerDislikeNotFoundException()
    {
        TitleMessage = "Answer like  not found!";
    }
}