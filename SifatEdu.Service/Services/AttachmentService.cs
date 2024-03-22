using AutoMapper;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Data.Repasitories;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Attachment;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Extentions;
using SifatEdu.Service.Helpers;
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

    public async Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        var webrootPath = Path.Combine(PathHelper.WebRootPath, "Files");

        if (!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileExtension = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtension}";
        var fullPath = Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var createdAttachment = new Attachment
        {
            FileName = fileName,
            FilePath = fullPath
        };
        await this.repasitory.CreateAsync(createdAttachment);
        await this.repasitory.SaveAsync();

        return createdAttachment;

    }
}