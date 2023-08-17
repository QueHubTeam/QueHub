namespace QueHub.Service.Exceptions.Answers;

public class QuestionNotFoundExcaption : NotFoundException
{
    public QuestionNotFoundExcaption()
    {
        TitleMessage = "Answer not found!";
    }
}