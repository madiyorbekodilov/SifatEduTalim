using AutoMapper;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Answer;
using SifatEdu.Service.DTOs.Attachment;
using SifatEdu.Service.DTOs.CodeUchun;
using SifatEdu.Service.DTOs.Participate;
using SifatEdu.Service.DTOs.Question;
using SifatEdu.Service.DTOs.Test;
using SifatEdu.Service.DTOs.User;

namespace SifatEdu.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();

        //Answer
        CreateMap<Answer, AnswerResultDto>().ReverseMap();
        CreateMap<AnswerUpdateDto, Answer>().ReverseMap();
        CreateMap<AnswerCreationDto, Answer>().ReverseMap();

        //Attachment
        CreateMap<Attachment, AttachmentResultDto>().ReverseMap();
        CreateMap<AttachmentCreationDto, Attachment>().ReverseMap();

        //Participate
        CreateMap<Participate, ParticipateResultDto>().ReverseMap();
        CreateMap<ParticipateUpdateDto, Participate>().ReverseMap();
        CreateMap<ParticipateCreationDto, Participate>().ReverseMap();

        //Question
        CreateMap<Question, QuestionResultDto>().ReverseMap();
        CreateMap<QuestionUpdateDto, Question>().ReverseMap();
        CreateMap<QuestionCreationDto, Question>().ReverseMap();

        //Test
        CreateMap<Test, TestResultDto>().ReverseMap();
        CreateMap<TestUpdateDto, Test>().ReverseMap();
        CreateMap<TestCreationDto, Test>().ReverseMap();

        //Code
        CreateMap<CodeUchun, CodeUchunResultDto>().ReverseMap();
        CreateMap<CodeUchunUpdateDto, CodeUchun>().ReverseMap();
        CreateMap<CodeUchunCreationDto, CodeUchun>().ReverseMap();
    }
}