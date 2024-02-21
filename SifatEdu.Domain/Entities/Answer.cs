using SifatEdu.Domain.Commons;

namespace SifatEdu.Domain.Entities;

public class Answer : Auditable
{
    public string Javob { get; set; }
    public bool IsTrue { get; set; }
}