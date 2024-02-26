using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Test;
using SifatEdu.Service.DTOs.User;

namespace SifatEdu.Service.DTOs.Participate;

public class ParticipateResultDto
{
    public long Id { get; set; }
    public long CountOfTrue { get; set; }
    public long Ball { get; set; }

    public TestResultDto TestResult { get; set; }
    public UserResultDto UserResult { get; set; }
}