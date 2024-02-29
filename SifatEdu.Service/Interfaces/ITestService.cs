using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Test;

namespace SifatEdu.Service.Interfaces;

public interface ITestService
{
    Task<bool> DeleteAsync(long id);
    Task<bool> SearchExamAsync(long id);
    Task<IEnumerable<Test>> GetAllAsync();
    Task<TestResultDto> GetByIdAsync(long id);
    Task<IEnumerable<TestResultDto>> EndedExams();
    Task<IEnumerable<TestResultDto>> FutureExams();
    Task<IEnumerable<TestResultDto>> CurrentExams();
    Task<TestResultDto> ModifyAsync(TestUpdateDto examUpdate);
    Task<IEnumerable<TestResultDto>> GetByTitleAsync(string title);
    Task<TestResultDto> CreateAsync(TestCreationDto examCreation);
    Task<IEnumerable<TestResultDto>> GetByNearExamAsync(DateTime dateTime);
}