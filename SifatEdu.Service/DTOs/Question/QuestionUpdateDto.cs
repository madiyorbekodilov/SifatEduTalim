namespace SifatEdu.Service.DTOs.Question;

public class QuestionUpdateDto
{
    public long Id { get; set; }
    public string Savol { get; set; }
    public bool isCode { get; set; }

    public long? AttachmentId { get; set; }
}