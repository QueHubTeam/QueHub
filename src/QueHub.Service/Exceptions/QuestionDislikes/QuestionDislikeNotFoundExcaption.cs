namespace QueHub.Service.Exceptions.QuestionDislikes;

public class QuestionDislikeNotFoundExcaption : NotFoundException
{
    public QuestionDislikeNotFoundExcaption()
    {
       TitleMessage = "Question dislike  not found!";
    }
}