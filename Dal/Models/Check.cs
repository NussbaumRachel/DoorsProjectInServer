using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Check
{
    public int Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }
}
