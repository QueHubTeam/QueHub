namespace QueHub.Service.Exceptions.Answers;

public class QuestionNotFoundException : NotFoundException
{
    public QuestionNotFoundException()
    {
        TitleMessage = "Answer not found!";
    }
}