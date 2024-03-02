using AutoMapper;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.Interfaces;
using SifatEdu.Service.Exceptions;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Service.DTOs.Answer;

namespace SifatEdu.Service.Services;

public class AnswerService : IAnswerService
{
    private readonly IMapper mapper;
    private readonly IRepasitory<Answer> repasitory;
    private readonly IQuestionService questionService;

    public AnswerService(IRepasitory<Answer> repasitory,IQuestionService questionService, IMapper mapper)
    {
        this.mapper = mapper;
        this.repasitory = repasitory;
        this.questionService = questionService;
    }
    public async Task<AnswerResultDto> CreateAsync(AnswerCreationDto answerCreation)
    {
        var existQuestion = await this.questionService.GetByIdAsync(answerCreation.QuestionId);

        if (existQuestion is null)
            throw new NotFoundException("Question not found");

        var answer = this.mapper.Map<Answer>(answerCreation);

        await this.repasitory.CreateAsync(answer);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<AnswerResultDto>(answer);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var answer = await this.repasitory.SelectAsync(x => x.Id == id);

        if (answer is null)
            throw new NotFoundException("Answer not found");

        this.repasitory.Delete(answer);
        await this.repasitory.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<Answer>> GetAllAsync()
    {
        return this.repasitory.SelectAll(null,true,new string[] { "Question" });
    }

    public async Task<AnswerResultDto> GetByIdAsync(long id)
    {
        var answer = await this.repasitory.SelectAsync(x => x.Id == id,new string[] {"Question"});

        if (answer is null)
            throw new NotFoundException("Answer not found");

        return this.mapper.Map<AnswerResultDto>(answer);
    }

    public async Task<IEnumerable<AnswerResultDto>> GetByQuestionIdAsync(long questionId)
    {
        var questionc = await this.questionService.GetByIdAsync(questionId);

        if (questionc is null)
            throw new NotFoundException("Question not found");

        var answers = this.repasitory.SelectAll(a => a.QuestionId == questionId);

        return this.mapper.Map<IEnumerable<AnswerResultDto>>(answers);
    }

    public async Task<AnswerResultDto> ModifyAsync(AnswerUpdateDto answerUpdate)
    {
        var exisAnswer = await this.repasitory.SelectAsync(x => x.Id == answerUpdate.Id);
        var exisQuestion = await this.questionService.GetByIdAsync(answerUpdate.QuestionId);

        if (exisAnswer is null)
            throw new NotFoundException("Answer not found");

        if (exisQuestion is null)
            throw new NotFoundException("Question not found");

        this.mapper.Map(answerUpdate, exisAnswer);

        this.repasitory.Update(exisAnswer);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<AnswerResultDto>(exisAnswer);
    }
}
