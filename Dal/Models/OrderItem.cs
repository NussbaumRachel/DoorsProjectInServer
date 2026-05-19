using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public byte ItemType { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public string? Status { get; set; }

    public DateTime? OrderItemDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Order Order { get; set; } = null!;
}
