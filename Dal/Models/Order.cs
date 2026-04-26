using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Order
{
    public int Id { get; set; }

    public string? CustId { get; set; }

    public string? CustName { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string? Street { get; set; }

    public string? Plot { get; set; }

    public int? BuildingNum { get; set; }

    public int? Floor { get; set; }

    public int? ApartmentNum { get; set; }

    public int? Price { get; set; }

    public string? Notes { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
