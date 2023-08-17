using QueHub.Service.DTOs.Questions;

namespace QueHub.Service.Interfaces;

public interface IQuestionService
{
    Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto);

    Task<QuestionResultDto> UpdateAsync(QuestionUpdateDto dto);

    Task<bool> DeleteAsync(long id);

    Task<QuestionResultDto> GetByIdAsync(long id);

    Task<IEnumerable<QuestionResultDto>> GetAllQAsync();

    Task<IEnumerable<QuestionResultDto>> GetByUserIdAsync(long userId);

    Task<IEnumerable<QuestionResultDto>> GetByCategoryIdAsync(long categoryId);

    Task<IEnumerable<QuestionResultDto>> SearchAsync(string searchTerm);

    Task<bool> UpdateImageAsync(long id, string imagePath);
}
