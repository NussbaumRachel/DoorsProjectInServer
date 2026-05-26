using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
