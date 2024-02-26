﻿using SifatEdu.Service.DTOs.Attachment;

namespace SifatEdu.Service.DTOs.Question;

public class QuestionResultDto
{
    public long Id { get; set; }
    public string Savol { get; set; }
    public bool isCode { get; set; }

    public AttachmentResultDto Attachment { get; set; }
}