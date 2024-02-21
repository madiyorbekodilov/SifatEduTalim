using SifatEdu.Domain.Commons;

namespace SifatEdu.Domain.Entities;

public class Attachment : Auditable
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
}