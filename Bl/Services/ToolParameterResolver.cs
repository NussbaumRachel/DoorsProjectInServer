using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bl.Models;

namespace Bl.Services
{
    public static class ToolParameterResolver
    {
        public static string Resolve(Operation op)
        {
            return op.Type switch
            {
                "HOLE" when op.Diameter <= 3
                    => $"RO {op.Diameter}",

                "HOLE"
                    => $"RO {op.Diameter}",

                "SQUARE"
                    => $"SQ {op.Width}",

                "CUT"
                    => "F GESHER_DLT.T",

                "REINFORCEMENT"
                    => "MJ 80 5 1.44 AI",

                "FASTENING"
                    => "F UP_3.2x13.5_DLT.T",

                _ => string.Empty
            };
        }
    }
}
