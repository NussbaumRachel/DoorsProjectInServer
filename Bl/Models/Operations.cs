using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class Operation
    {
        public string Type { get; set; }
        public double? Diameter { get; set; }
        public double? Width { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        //public List<Command> Commands { get; set; }
    }
}
