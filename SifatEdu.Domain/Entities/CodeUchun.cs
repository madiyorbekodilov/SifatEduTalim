namespace SifatEdu.Domain.Entities;

public class CodeUchun
{
    public long QuestionId { get; set; }
    public Question Question { get; set; }

    public string Kiruvchi { get; set; }
    public string Chiquchi { get; set; }
}