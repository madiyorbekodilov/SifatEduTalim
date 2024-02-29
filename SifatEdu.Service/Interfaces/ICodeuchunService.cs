using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.CodeUchun;

namespace SifatEdu.Service.Interfaces;

public interface ICodeuchunService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<CodeUchun>> GetAllAsync();
    Task<CodeUchunResultDto> GetByIdAsync(long id);
    Task<CodeUchunResultDto> ModifyAsync(CodeUchunUpdateDto CodeUpdate);
    Task<CodeUchunResultDto> CreateAsync(CodeUchunCreationDto CodeCreation);
    Task<IEnumerable<CodeUchunResultDto>> GetByQuestionIdAsync(long questionId);
}