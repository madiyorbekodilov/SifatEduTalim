using Microsoft.AspNetCore.Http;

namespace SifatEdu.Service.DTOs.Attachment;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; }
}