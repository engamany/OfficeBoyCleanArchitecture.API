using System;
using System.Collections.Generic;

namespace OfficeBoy.Models;

public partial class OfficeLocation
{
    public int OfficeLocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public int DeptId { get; set; }

    public int? FloorNumber { get; set; }

    public virtual Department Dept { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
