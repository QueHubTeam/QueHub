using QueHub.Domain.Entity.AnswerDislikes;
using QueHub.Domain.Entity.AnswerLikes;
using QueHub.Domain.Entity.Answers;
using QueHub.Domain.Entity.Category;
using QueHub.Domain.Entity.QuestionDislikes;
using QueHub.Domain.Entity.QuestionLikes;
using QueHub.Domain.Entity.Questions;
using QueHub.Domain.Entity.User;

namespace QueHub.DAL.IRepositories;

public interface IUnitOfWork
{
    IRepository<UserEntity> UserRepository { get; }

    IRepository<QuestionEntity> QuestionRepository { get; }

    IRepository<AnswerEntity> AnswerRepository { get; }

    IRepository<CategoryEntity> CategoryRepository { get; }

    IRepository<QuestionLikeEntity> QuestionLikeRepository { get; }

    IRepository<QuestionDislikeEntity> QuestionDislikeRepository { get; }

    IRepository<AnswerLikeEntity> AnswerLikeRepository { get; }

    IRepository<AnswerDislikeEntity> AnswerDislikeRepository { get; }

    Task<bool> SaveAsync();
}
