using QueHub.DAL.Constexts;
using QueHub.DAL.IRepositories;
using QueHub.DAL.Repository;
using QueHub.Domain.Entity.AnswerDislikes;
using QueHub.Domain.Entity.AnswerLikes;
using QueHub.Domain.Entity.Answers;
using QueHub.Domain.Entity.Category;
using QueHub.Domain.Entity.QuestionDislikes;
using QueHub.Domain.Entity.QuestionLikes;
using QueHub.Domain.Entity.Questions;
using QueHub.Domain.Entity.User;

namespace BermudTravel.DAL.Repository;

public class UnitOfWork : IUnitOfWork
{

    private readonly QueHubDbContext dbContext;

    public UnitOfWork(QueHubDbContext dbContext)
    {
        this.dbContext = dbContext;

        UserRepository = new Repository<UserEntity>(dbContext);
        QuestionRepository = new Repository<QuestionEntity>(dbContext);
        AnswerRepository = new Repository<AnswerEntity>(dbContext);
        CategoryRepository = new Repository<CategoryEntity>(dbContext);
        QuestionLikeRepository = new Repository<QuestionLikeEntity>(dbContext);
        QuestionDislikeRepository = new Repository<QuestionDislikeEntity>(dbContext);
        AnswerLikeRepository = new Repository<AnswerLikeEntity>(dbContext);
        AnswerDislikeRepository = new Repository<AnswerDislikeEntity>(dbContext);
    }

    public IRepository<UserEntity> UserRepository { get; }

    public IRepository<QuestionEntity> QuestionRepository { get; }

    public IRepository<AnswerEntity> AnswerRepository { get; }

    public IRepository<CategoryEntity> CategoryRepository { get; }

    public IRepository<QuestionLikeEntity> QuestionLikeRepository { get; }

    public IRepository<QuestionDislikeEntity> QuestionDislikeRepository { get; }

    public IRepository<AnswerLikeEntity> AnswerLikeRepository { get; }

    public IRepository<AnswerDislikeEntity> AnswerDislikeRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task<bool> SaveAsync()
    {
        return await dbContext.SaveChangesAsync() > 0;
    }
}