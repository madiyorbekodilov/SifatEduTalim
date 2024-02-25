using SifatEdu.Domain.Commons;

namespace SifatEdu.Domain.Entities;

public class Answer : Auditable
{
    public long QuestionId { get; set; }
    public Question Question { get; set; }

    public string Javob { get; set; }
    public bool IsTrue { get; set; }
}