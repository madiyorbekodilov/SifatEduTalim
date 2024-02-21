using SifatEdu.Domain.Commons;

namespace SifatEdu.Domain.Entities;

public class Participate : Auditable
{
    public long TesId { get; set; }
    public long CountOfTrue { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}