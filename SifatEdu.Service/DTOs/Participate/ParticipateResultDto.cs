using SifatEdu.Domain.Entities;

namespace SifatEdu.Service.DTOs.Participate;

public class ParticipateResultDto
{
    public long Id { get; set; }
    public long CountOfTrue { get; set; }
    public long Ball { get; set; }
}