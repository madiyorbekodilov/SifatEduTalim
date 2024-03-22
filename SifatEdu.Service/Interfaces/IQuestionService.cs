using Microsoft.AspNetCore.Http;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Attachment;
using SifatEdu.Service.DTOs.Question;

namespace SifatEdu.Service.Interfaces;

public interface IQuestionService
{
    Task<bool> DeleteAsync(long id);
    Task<QuestionResultDto> GetByIdAsync(long id);
    Task<IEnumerable<QuestionResultDto>> GetAllAsync();
    Task<ICollection<Question>> GetByTestIdAsync(long id);
    Task<bool> ModifyImageAsync(long id, IFormFile image);
    Task<QuestionResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto);
    Task<QuestionResultDto> ModifyAsync(QuestionUpdateDto dto);
    Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto);
}