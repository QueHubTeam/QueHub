namespace QueHub.Domain.Exceptions.QuestionLikes;

public class QuestionLikeNotFoundExcaption : NotFoundException 
{
    public QuestionLikeNotFoundExcaption()
    {
        TitleMessage = "Question like  not found!";
    }

}