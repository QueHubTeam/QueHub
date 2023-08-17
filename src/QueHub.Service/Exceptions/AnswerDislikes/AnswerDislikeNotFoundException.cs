namespace QueHub.Service.Exceptions.AnswerLikes;

public class AnswerDislikeNotFoundException : NotFoundException
{
    public AnswerDislikeNotFoundException()
    {
        TitleMessage = "Answer dislike not found!";
    }
}