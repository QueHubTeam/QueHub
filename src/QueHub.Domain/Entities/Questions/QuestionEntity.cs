using QueHub.Domain.Commons;
using QueHub.Domain.Entity.Category;
using QueHub.Domain.Entity.User;

namespace QueHub.Domain.Entity.Questions;

public class QuestionEntity : Auditable
{
    public long UserId { get; set; }
    public UserEntity User { get; set; }

    public long CategoryId { get; set; }
    public CategoryEntity Category { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}