using Bl.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
namespace Bl.Services
{
    public class SkylightRule : IBlDoorRule
    {
        public List<Operation> Apply(BlDoor door)
        {
            if (string.IsNullOrEmpty(door.Skylight))
                return new List<Operation>();

            return new List<Operation>
        {
            new Operation
            {
                Type = "CUT",
               Y  = (double)door.Width / 2,
               X  = (double)door.Height / 2
            }
        };
        }
    }
}
