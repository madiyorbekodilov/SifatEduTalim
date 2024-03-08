namespace SifatEdu.Service.DTOs.Question;

public class QuestionCreationDto
{
    public string Savol { get; set; }
    public bool isCode { get; set; }

    public long TestId { get; set;}
    public long? AttachmentId { get; set; }
}