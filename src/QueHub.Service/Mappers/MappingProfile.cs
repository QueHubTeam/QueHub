using AutoMapper;
using QueHub.Domain.Entity.Answers;
using QueHub.Domain.Entity.Category;
using QueHub.Domain.Entity.Questions;
using QueHub.Domain.Entity.User;
using QueHub.Service.DTOs.Answers;
using QueHub.Service.DTOs.Categories;
using QueHub.Service.DTOs.Questions;
using QueHub.Service.DTOs.Users;

namespace QueHub.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        //user

        CreateMap<UserCreationDto, UserEntity>().ReverseMap();
        CreateMap<UserUpdateDto, UserEntity>().ReverseMap();
        CreateMap<UserEntity, UserResultDto>().ReverseMap();
        CreateMap<UserCreationDto, UserResultDto>().ReverseMap();
        CreateMap<UserUpdateDto, UserResultDto>().ReverseMap();

        //question

        CreateMap<QuestionCreationDto, QuestionEntity>().ReverseMap();
        CreateMap<QuestionUpdateDto, QuestionEntity>().ReverseMap();
        CreateMap<QuestionEntity, QuestionResultDto>().ReverseMap();
        CreateMap<QuestionCreationDto, QuestionResultDto>().ReverseMap();
        CreateMap<QuestionUpdateDto, QuestionResultDto>().ReverseMap();

        //answer

        CreateMap<AnswerCreationDto, AnswerEntity>().ReverseMap();
        CreateMap<AnswerUpdateDto, AnswerEntity>().ReverseMap();
        CreateMap<AnswerEntity, AnswerResultDto>().ReverseMap();
        CreateMap<AnswerCreationDto, AnswerResultDto>().ReverseMap();
        CreateMap<AnswerUpdateDto, AnswerResultDto>().ReverseMap();

        //category

        CreateMap<CategoryCreationDto, CategoryEntity>().ReverseMap();
        CreateMap<CategoryUpdateDto, CategoryEntity>().ReverseMap();
        CreateMap<CategoryEntity, CategoryResultDto>().ReverseMap();
        CreateMap<CategoryCreationDto, CategoryResultDto>().ReverseMap();
        CreateMap<CategoryUpdateDto, CategoryResultDto>().ReverseMap();
    }
}
