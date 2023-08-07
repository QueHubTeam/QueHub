namespace QueHub.Domain.Exceptions.Questions;

public class QuestionNotFoundExcaption : NotFoundException
{
    public QuestionNotFoundExcaption()
    {
        TitleMessage = "Question not found!";
    }
}