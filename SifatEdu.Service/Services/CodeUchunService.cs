using AutoMapper;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Interfaces;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Service.DTOs.CodeUchun;

namespace SifatEdu.Service.Services;

public class CodeUchunService : ICodeuchunService
{
    private readonly IMapper mapper;
    private readonly IRepasitory<CodeUchun> repasitory;
    private readonly IQuestionService questionService;

    public CodeUchunService(IRepasitory<CodeUchun> repasitory, IQuestionService questionService, IMapper mapper)
    {
        this.mapper = mapper;
        this.repasitory = repasitory;
        this.questionService = questionService;
    }

    public async Task<CodeUchunResultDto> CreateAsync(CodeUchunCreationDto CodeCreation)
    {
        var existQuestion = await this.questionService.GetByIdAsync(CodeCreation.QuestionId);

        if (existQuestion is null)
            throw new NotFoundException("Question not found");

        var answer = this.mapper.Map<CodeUchun>(CodeCreation);

        await this.repasitory.CreateAsync(answer);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<CodeUchunResultDto>(answer);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var question = await repasitory.SelectAsync(x => x.Id == id);

        if (question is null)
            throw new NotFoundException("Not found");

        this.repasitory.Delete(question);
        await this.repasitory.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<CodeUchun>> GetAllAsync()
    {
        return this.repasitory.SelectAll(null, true, new string[] { "Question" });
    }

    public async Task<CodeUchunResultDto> GetByIdAsync(long id)
    {
        var dats = await this.repasitory.SelectAsync(x => x.Id == id);

        if (dats is null)
            throw new NotFoundException("Malumot topilmadi");

        return this.mapper.Map<CodeUchunResultDto>(dats);
    }

    public async Task<IEnumerable<CodeUchunResultDto>> GetByQuestionIdAsync(long questionId)
    {
        var questionc = await this.questionService.GetByIdAsync(questionId);

        if (questionc is null)
            throw new NotFoundException("Not found");

        var answers = this.repasitory.SelectAll(a => a.QuestionId == questionId);

        return this.mapper.Map<IEnumerable<CodeUchunResultDto>>(answers);
    }

    public async Task<CodeUchunResultDto> ModifyAsync(CodeUchunUpdateDto CodeUpdate)
    {
        var exisAnswer = await this.repasitory.SelectAsync(x => x.Id == CodeUpdate.Id);
        var exisQuestion = await this.questionService.GetByIdAsync(CodeUpdate.QuestionId);

        if (exisAnswer is null)
            throw new NotFoundException("Answer not found");

        if (exisQuestion is null)
            throw new NotFoundException("Question not found");

        this.mapper.Map(CodeUpdate, exisAnswer);

        this.repasitory.Update(exisAnswer);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<CodeUchunResultDto>(exisAnswer);
    }
}