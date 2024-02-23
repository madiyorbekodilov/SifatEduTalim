﻿using SifatEdu.Domain.Commons;

namespace SifatEdu.Domain.Entities;

public class Question : Auditable
{
    public string Savol { get; set; }

    public long AnswerId { get; set; }
    public Answer Answer { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}