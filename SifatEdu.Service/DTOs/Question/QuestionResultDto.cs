﻿using SifatEdu.Service.DTOs.Answer;
using SifatEdu.Service.DTOs.Attachment;
using SifatEdu.Service.DTOs.CodeUchun;

namespace SifatEdu.Service.DTOs.Question;

public class QuestionResultDto
{
    public long Id { get; set; }
    public string Savol { get; set; }
    public bool isCode { get; set; }
    public ICollection<AnswerResultDto> Answers { get; set; }
    public ICollection<CodeUchunResultDto> Codes { get; set; }

    public AttachmentResultDto Attachment { get; set; }

}