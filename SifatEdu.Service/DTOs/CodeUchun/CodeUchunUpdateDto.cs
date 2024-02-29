namespace SifatEdu.Service.DTOs.CodeUchun;

public class CodeUchunUpdateDto
{
    public long Id { get; set; }
    public long QuestionId { get; set; }

    public string Kiruvchi { get; set; }
    public string Chiquchi { get; set; }
}