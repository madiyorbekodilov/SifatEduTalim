using Microsoft.AspNetCore.Http;
using SifatEdu.Service.DTOs.Question;

namespace SifatEdu.Service.Interfaces;

public interface IQuestionService
{
    Task<bool> DeleteAsync(long id);
    Task<QuestionResultDto> GetByIdAsync(long id);
    Task<IEnumerable<QuestionResultDto>> GetAllAsync();
    Task<bool> ModifyImageAsync(long id, IFormFile image);
    Task<QuestionResultDto> ModifyAsync(QuestionUpdateDto dto);
    Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto);
}