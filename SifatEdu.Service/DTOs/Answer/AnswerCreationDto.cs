namespace SifatEdu.Service.DTOs.Answer;

public class AnswerCreationDto
{
    public long QuestionId { get; set; }

    public string Javob { get; set; }
    public bool IsTrue { get; set; }
}