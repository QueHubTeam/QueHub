using Microsoft.EntityFrameworkCore;
using QueHub.DAL.Constans;
using QueHub.Domain.Entity.AnswerDislikes;
using QueHub.Domain.Entity.AnswerLikes;
using QueHub.Domain.Entity.Answers;
using QueHub.Domain.Entity.Category;
using QueHub.Domain.Entity.QuestionDislikes;
using QueHub.Domain.Entity.QuestionLikes;
using QueHub.Domain.Entity.Questions;
using QueHub.Domain.Entity.User;

namespace QueHub.DAL.Constexts;

public class QueHubDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<QuestionEntity> Questions { get; set; }

    public DbSet<AnswerEntity> Answers { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<QuestionLikeEntity> QuestionLikes { get; set; }

    public DbSet<QuestionDislikeEntity> QuestionDislikes { get; set; }

    public DbSet<AnswerLikeEntity> AnswerLikes { get; set; }

    public DbSet<AnswerDislikeEntity> AnswerDislikes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(DbConstans.CONNECTION_STRING);
    }
}
