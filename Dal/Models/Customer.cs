using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public string? Status { get; set; }

    public string? ContactPersonPhone { get; set; }

    public string? ContactPersonName { get; set; }

    public string? Cn { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
