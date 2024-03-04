using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Test;

namespace SifatEdu.Service.Interfaces;

public interface ITestService
{
    Task<bool> DeleteAsync(long id);
    Task<bool> SearchExamAsync(long id);
    Task<IEnumerable<Test>> GetAllAsync();
    Task<TestResultDto> GetByIdAsync(long id);
    Task<TestResultDto> ModifyAsync(TestUpdateDto examUpdate);
    Task<TestResultDto> CreateAsync(TestCreationDto examCreation);
}