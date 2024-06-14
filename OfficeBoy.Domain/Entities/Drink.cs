using System;
using System.Collections.Generic;

namespace OfficeBoy.Models;

public partial class Drink
{
    public int DrinkId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? PictureUrl { get; set; }

    public bool Availability { get; set; }

    public int? TimeNeeded { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
