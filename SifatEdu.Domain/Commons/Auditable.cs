﻿namespace SifatEdu.Domain.Commons;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
}
