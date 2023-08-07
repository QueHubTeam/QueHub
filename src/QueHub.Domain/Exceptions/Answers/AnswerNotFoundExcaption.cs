namespace QueHub.Domain.Exceptions.Answers;

public class QuestionNotFoundExcaption : NotFoundException
{
    public QuestionNotFoundExcaption()
    {
        TitleMessage = "Answer not found!";
    }
}