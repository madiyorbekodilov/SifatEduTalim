using AutoMapper;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Participate;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Service.Services;

public class ParticipateService : IParticipateService
{
    private readonly IMapper mapper;
    private readonly IRepasitory<Participate> repasitory;

    public ParticipateService(IRepasitory<Participate> repasitory, IMapper mapper)
    {
        this.mapper = mapper;
        this.repasitory = repasitory;
    }

    public Task<ParticipateResultDto> CreateAsync(ParticipateCreationDto creationDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ParticipateResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ParticipateResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ParticipateResultDto>> GetByTestId(long testId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ParticipateResultDto>> GetByUserId(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<float> MyScore(long userId, long examId)
    {
        throw new NotImplementedException();
    }

    public Task<ParticipateResultDto> UpdateAsync(ParticipateUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }
}