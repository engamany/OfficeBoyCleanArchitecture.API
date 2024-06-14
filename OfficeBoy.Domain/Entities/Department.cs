using System;
using System.Collections.Generic;

namespace OfficeBoy.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<OfficeLocation> OfficeLocations { get; set; } = new List<OfficeLocation>();
}
