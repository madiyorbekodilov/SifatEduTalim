using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Attachment;

namespace SifatEdu.Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> DeleteAsync(long id);
}