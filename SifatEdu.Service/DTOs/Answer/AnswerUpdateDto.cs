namespace SifatEdu.Service.DTOs.Answer;

public class AnswerUpdateDto
{
    public long Id { get; set; }
    public bool isCorrect { get; set; }
    public string Javob { get; set; }

    public long QuestionId { get; set; }
}