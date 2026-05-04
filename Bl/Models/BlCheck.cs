using System;
using System.Collections.Generic;
using Dal.Models;

namespace Bl.Models;

public class BlCheck
{

    //public int Id { get; set; }
    public string? Key { get; set; }
    public List<Check> Values { get; set; } = new List<Check>();
}
