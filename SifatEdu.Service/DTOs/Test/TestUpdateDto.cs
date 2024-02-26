namespace SifatEdu.Service.DTOs.Test;

public class TestUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CountQuestion { get; set; }
    public int QuizNumber { get; set; }

    public long QuestionId { get; set; }
}