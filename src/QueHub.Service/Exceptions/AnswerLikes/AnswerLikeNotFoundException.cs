namespace QueHub.Service.Exceptions.AnswerDislikes;

public class AnswerDislikeNotFoundException : NotFoundException
{
    public AnswerDislikeNotFoundException()
    {
        TitleMessage = "Answer like not found!";
    }
}