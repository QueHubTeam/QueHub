namespace QueHub.Service.Exceptions.Answers;

public class AnswerNotFoundException : NotFoundException
{
    public AnswerNotFoundException()
    {
        TitleMessage = "Answer not found!";
    }
}