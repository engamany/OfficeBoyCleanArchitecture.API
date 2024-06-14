using System;
using System.Collections.Generic;

namespace OfficeBoy.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? OfficeLocationId { get; set; }

  

    public virtual ICollection<OfficeBoyShift> OfficeBoyShifts { get; set; } = new List<OfficeBoyShift>();

    public virtual OfficeLocation? OfficeLocation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

  
}
