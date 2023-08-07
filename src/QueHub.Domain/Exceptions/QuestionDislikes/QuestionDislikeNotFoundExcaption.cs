
namespace QueHub.Domain.Exceptions.QuestionDislikes;

public class QuestionDislikeNotFoundExcaption : NotFoundException
{

    public QuestionDislikeNotFoundExcaption()
    {
       TitleMessage = "Question dislike  not found!";
    }

}