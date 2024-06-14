using System;
using System.Collections.Generic;

namespace OfficeBoy.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int EmpId { get; set; }

    public int DrinkId { get; set; }

    public int Quantity { get; set; }

    public int OfficeLocationId { get; set; }

    public bool IndividualOrder { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateTime Orderdate { get; set; }

    public bool IsCompany { get; set; }

    public virtual Drink Drink { get; set; } = null!;

    public virtual Employee Emp { get; set; } = null!;

    public virtual OfficeLocation OfficeLocation { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
