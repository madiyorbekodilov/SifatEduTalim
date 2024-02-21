﻿using SifatEdu.Domain.Commons;

namespace SifatEdu.Domain.Entities;

public class Test : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CountQuestion { get; set; }
    public int QuizNumber { get; set; }

    public long QuestionId { get; set; }
    public Question Question { get; set; }
}