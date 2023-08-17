using BermudTravel.DAL.Repository;
using QueHub.DAL.IRepositories;
using QueHub.DAL.Repository;
using QueHub.Service.Interfaces;
using QueHub.Service.Mappers;
using QueHub.Service.Services;

namespace QueHub.WebApi.Extensions;

public static class ServicesCollection
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IUserService, UserService>();
    }
}
