using Bl.Api;
using System;
using System.Collections.Generic;

namespace Bl.Models;

public class BlCustomer
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
    public bool Equals(BlCustomer c)
    {
        return Id == c.Id && Name == c.Name;
    }
}
