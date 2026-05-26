using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class Command
    {
        public string Code { get; set; }        // G01 / G4 / M25 / STOPRE / RAM / CLAMP וכו'
        public string Arguments { get; set; }   // X2043 Y852.497 / F0.2 / TOOL120 וכו'
    }
}
