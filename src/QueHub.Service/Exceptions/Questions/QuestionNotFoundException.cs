namespace QueHub.Service.Exceptions.Questions;

public class QuestionNotFoundException : NotFoundException
{
    public QuestionNotFoundException()
    {
        TitleMessage = "Question not found!";
    }
}