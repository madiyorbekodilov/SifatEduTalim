using AutoMapper;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.CodeUchun;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Service.Services;

public class CodeUchunService : ICodeuchunService
{
    private readonly IMapper mapper;
    private readonly IRepasitory<CodeUchun> repasitory;

    public CodeUchunService(IRepasitory<CodeUchun> repasitory, IMapper mapper)
    {
        this.mapper = mapper;
        this.repasitory = repasitory;
    }

    public Task<CodeUchunResultDto> CreateAsync(CodeUchunCreationDto CodeCreation)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CodeUchun>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CodeUchunResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CodeUchunResultDto>> GetByQuestionIdAsync(long questionId)
    {
        throw new NotImplementedException();
    }

    public Task<CodeUchunResultDto> ModifyAsync(CodeUchunUpdateDto CodeUpdate)
    {
        throw new NotImplementedException();
    }
}