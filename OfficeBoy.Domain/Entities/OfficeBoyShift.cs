using System;
using System.Collections.Generic;

namespace OfficeBoy.Models;

public partial class OfficeBoyShift
{
    public int ShiftId { get; set; }

    public int EmpId { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int? DayShift { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
