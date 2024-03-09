using SifatEdu.Service.DTOs.Answer;
using SifatEdu.Service.DTOs.Question;

namespace SifatEdu.Service.DTOs.Test;

public class TestResultDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CountQuestion { get; set; }
    public int QuizNumber { get; set; }

    public ICollection<QuestionResultDto> Questions { get; set; }
}