using AutoMapper;
using QueHub.DAL.IRepositories;
using QueHub.Domain.Entity.Questions;
using QueHub.Service.DTOs.Questions;
using QueHub.Service.Exceptions.Categories;
using QueHub.Service.Exceptions.Questions;
using QueHub.Service.Interfaces;

namespace QueHub.Service.Services;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto)
    {
        var exsistingCategory = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Id == dto.CategoryId);
        if (exsistingCategory is null)
            throw new CategoryNotFoundException();

        var question = _mapper.Map<QuestionEntity>(dto);
        var addedQuestion = await _unitOfWork.QuestionRepository.AddAsync(question);
        await _unitOfWork.SaveAsync();

        var resultDto = _mapper.Map<QuestionResultDto>(addedQuestion);
        return resultDto;
    }

    public async Task<QuestionResultDto> UpdateAsync(QuestionUpdateDto dto)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == dto.Id);
        if (question == null)
            throw new QuestionNotFoundException();

        var exsistingCategory = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Id == dto.CategoryId);
        if (exsistingCategory is null)
            throw new CategoryNotFoundException();

        _mapper.Map(dto, question);
        var updatedQuestion = await _unitOfWork.QuestionRepository.UpdateAsync(question);
        await _unitOfWork.SaveAsync();

        var resultDto = _mapper.Map<QuestionResultDto>(updatedQuestion);
        return resultDto;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);
        if (question == null)
            throw new QuestionNotFoundException();

        await _unitOfWork.QuestionRepository.DeleteAsync(q => q == question);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<QuestionResultDto> GetByIdAsync(long id)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);
        if (question == null)
            throw new QuestionNotFoundException();

        var resultDto = _mapper.Map<QuestionResultDto>(question);
        return resultDto;
    }

    public async Task<IEnumerable<QuestionResultDto>> GetAllQAsync()
    {
        var questions = _unitOfWork.QuestionRepository.SelectAll();
        var resultDtos = _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        return resultDtos;
    }

    public async Task<IEnumerable<QuestionResultDto>> GetByUserIdAsync(long userId)
    {
        var questions = _unitOfWork.QuestionRepository.SelectAll(q => q.UserId == userId);
        var resultDtos = _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        return resultDtos;
    }

    public async Task<IEnumerable<QuestionResultDto>> GetByCategoryIdAsync(long categoryId)
    {
        var questions = _unitOfWork.QuestionRepository.SelectAll(q => q.CategoryId == categoryId);
        var resultDtos = _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        return resultDtos;
    }

    public async Task<IEnumerable<QuestionResultDto>> SearchAsync(string searchTerm)
    {
        var questions = _unitOfWork.QuestionRepository.SelectAll(q =>
            q.Title.Contains(searchTerm) || q.Content.Contains(searchTerm));
        var resultDtos = _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        return resultDtos;
    }

    public async Task<bool> UpdateImageAsync(long id, string imagePath)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);
        if (question == null)
            throw new QuestionNotFoundException();

        question.ImagePath = imagePath;
        await _unitOfWork.SaveAsync();
        return true;
    }
}
