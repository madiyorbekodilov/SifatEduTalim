using AutoMapper;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Test;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Interfaces;
using SifatEdu.Data.IRepasitories;

namespace SifatEdu.Service.Services;

public class TestService : ITestService
{

    private readonly IMapper mapper;
    private readonly IRepasitory<Test> repasitory;

    public TestService(IRepasitory<Test> repasitory, IMapper mapper)
    {
        this.mapper = mapper;
        this.repasitory = repasitory;
    }

    public async Task<TestResultDto> CreateAsync(TestCreationDto examCreation)
    {
        var testnew = this.mapper.Map<Test>(examCreation);

        await this.repasitory.CreateAsync(testnew);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<TestResultDto>(testnew);

    }


    public async Task<bool> DeleteAsync(long id)
    {
        var exisTest = await this.repasitory.SelectAsync(x => x.Id == id);

        if (exisTest is null)
            throw new NotFoundException("Test not found");

        this.repasitory.Delete(exisTest);
        await this.repasitory.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<TestResultDto>> GetAllAsync()
    {
        var tests = this.repasitory.SelectAll(includes: new string[] { "Questions" });
        return this.mapper.Map<IEnumerable<TestResultDto>>(tests);
    }

    public async Task<TestResultDto> GetByIdAsync(long id)
    {
        var exisTest = await this.repasitory.SelectAsync(x => x.Id == id, new string[] { "Questions"});

        if (exisTest is null)
            throw new NotFoundException("Test not found");

        return this.mapper.Map<TestResultDto>(exisTest);
    }

    public async Task<TestResultDto> ModifyAsync(TestUpdateDto examUpdate)
    {
        var existest = await this.repasitory.SelectAsync(x => x.Id == examUpdate.Id);

        if (existest is null)
            throw new NotFoundException("Test not found");

        this.mapper.Map(examUpdate, existest);
        this.repasitory.Update(existest);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<TestResultDto>(existest);
    }

    public async Task<bool> SearchExamAsync(long id)
    {
        var exisTest = await this.repasitory.SelectAsync(x => x.Id == id);

        if (exisTest is null)
            return false;

        return true;
    }
}