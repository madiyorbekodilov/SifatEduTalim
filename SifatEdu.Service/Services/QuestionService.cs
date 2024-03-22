using AutoMapper;
using Microsoft.AspNetCore.Http;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Interfaces;
using SifatEdu.Service.DTOs.Question;
using SifatEdu.Service.DTOs.Attachment;

namespace SifatEdu.Service.Services;

public class QuestionService : IQuestionService
{
    private readonly IMapper mapper;
    private readonly IRepasitory<Question> repasitory;
    private readonly IAttachmentService attachment;

    public QuestionService(IRepasitory<Question> repasitory,IAttachmentService attachment,IMapper mapper)
    {
        this.mapper = mapper;
        this.repasitory = repasitory;
        this.attachment = attachment;
    }

    public async Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto)
    {
        var question = mapper.Map<Question>(dto);
        await this.repasitory.CreateAsync(question);
        await this.repasitory.SaveAsync();

        return mapper.Map<QuestionResultDto>(question);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var question = await repasitory.SelectAsync(x => x.Id == id);

        if (question is null)
            throw new NotFoundException("Question not found");

        this.repasitory.Delete(question);
        await this.repasitory.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<QuestionResultDto>> GetAllAsync()
    {
        var questions = this.repasitory.SelectAll(includes: new string[] { "Answers", "Attachment", "Codes" });

        return  this.mapper.Map<IEnumerable<QuestionResultDto>>(questions);
    }

    public async Task<QuestionResultDto> GetByIdAsync(long id)
    {
        var question = await repasitory.SelectAsync(x => x.Id == id,
                                                includes: new string[] { "Answers" , "Codes", "Attachment" });

        if (question is null)
            throw new NotFoundException("Question not found");

        return this.mapper.Map<QuestionResultDto>(question);
    }

    public async Task<ICollection<Question>> GetByTestIdAsync(long id)
    {
        var questions = this.repasitory.SelectAll(includes: new string[] { "Answers", "Attachment", "Codes" });
        var natija = questions.Where(x => x.TestId == id);

        return this.mapper.Map<ICollection<Question>>(natija);
    }
    public async Task<QuestionResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto)
    {
        var question = await this.repasitory.SelectAsync(x => x.Id == productId);

        if (question is null)
            throw new NotFoundException("Question not found");

        var createdAttachment = await this.attachment.UploadAsync(dto);
        question.AttachmentId = createdAttachment.Id;
        question.Attachment = createdAttachment;

        this.repasitory.Update(question);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<QuestionResultDto>(question);
    }

    public async Task<QuestionResultDto> ModifyAsync(QuestionUpdateDto dto)
    {
        var question = await this.repasitory.SelectAsync(x => x.Id == dto.Id);

        if (question is null)
            throw new NotFoundException("Question not found");

        this.mapper.Map(question, dto);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<QuestionResultDto>(question);
    }

    public async Task<bool> ModifyImageAsync(long id, IFormFile image)
    {
        var question = await this.repasitory.SelectAsync(x => x.Id == id);

        if (question is null)
            throw new NotFoundException("Question not found");

        var attachment = await this.attachment.UploadAsync(new AttachmentCreationDto { FormFile = image });

        question.AttachmentId = attachment.Id;
        question.Attachment = attachment;

        await this.repasitory.SaveAsync();

        return true;
    }
}