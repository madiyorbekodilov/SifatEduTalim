using SifatEdu.Service.DTOs.Participate;

namespace SifatEdu.Service.Interfaces;

public interface IParticipateService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<ParticipateResultDto>> GetAllAsync();
    Task<ParticipateResultDto> GetByIdAsync(long id);
    Task<IEnumerable<ParticipateResultDto>> GetByTestId(long testId);
    Task<IEnumerable<ParticipateResultDto>> GetByUserId(long userId);
    Task<float> MyScore(long userId, long examId);
    Task<ParticipateResultDto> UpdateAsync(ParticipateUpdateDto updateDto);
    Task<ParticipateResultDto> CreateAsync(ParticipateCreationDto creationDto);
}