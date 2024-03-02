using AutoMapper;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Attachment;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepasitory<Attachment> repasitory;
    private readonly IMapper mapper;

    public AttachmentService(IRepasitory<Attachment> repasitory, IMapper mapper)
    {
        this.repasitory = repasitory;
        this.mapper = mapper;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var attachment = await repasitory.SelectAsync(x => x.Id == id);

        if (attachment is null)
            throw new NotFoundException("Attachment not found");

        repasitory.Delete(attachment);
        await this.repasitory.SaveAsync();

        return true;
    }

    public Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        throw new NotImplementedException();
    }
}