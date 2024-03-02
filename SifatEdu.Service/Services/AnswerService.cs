using AutoMapper;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Answer;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Service.Services;

public class AnswerService : IAnswerService
{
    private readonly IMapper mapper;
    private readonly IRepasitory<Answer> repasitory;

    public AnswerService(IRepasitory<Answer> repasitory, IMapper mapper)
    {
        this.repasitory = repasitory;
        this.mapper = mapper;
    }
    public Task<AnswerResultDto> CreateAsync(AnswerCreationDto answerCreation)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Answer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AnswerResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnswerResultDto>> GetByQuestionIdAsync(long questionId)
    {
        throw new NotImplementedException();
    }

    public Task<AnswerResultDto> ModifyAsync(AnswerUpdateDto answerUpdate)
    {
        throw new NotImplementedException();
    }
}
