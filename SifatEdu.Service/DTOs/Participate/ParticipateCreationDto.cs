using SifatEdu.Domain.Entities;

namespace SifatEdu.Service.DTOs.Participate;

public class ParticipateCreationDto
{
    public long CountOfTrue { get; set; }
    public long Ball { get; set; }

    public long TesId { get; set; }
    public long UserId { get; set; }
}