using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
namespace Bl.Services
{
    public class ToolRules
    {
        public static string Resolve(Operation op)
        {
            return op.Type switch
            {
                "HOLE" when op.Diameter <= 3 => "T120",
                "HOLE" => "T403",

                "SQUARE" when op.Width == 12 => "T105",
                "SQUARE" when op.Width == 22 => "T109",

                "CUT" => "T418",

                "REINFORCEMENT" => "T301",

                "FASTENING" => "T108",

                _ => "UNKNOWN"
            };
        }
    }
}
