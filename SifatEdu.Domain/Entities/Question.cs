using SifatEdu.Domain.Commons;

namespace SifatEdu.Domain.Entities;

public class Question : Auditable
{
    public string Savol { get; set; }
    public bool isCode { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public long TestId { get; set; }
    public Test Test { get; set; }

    public ICollection<Answer> Answers { get; set; }

    public ICollection<CodeUchun> Codes { get; set; }
}