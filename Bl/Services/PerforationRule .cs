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
    public class PerforationRule : IBlDoorRule
    {
        public List<Operation> Apply(BlDoor door)
        {
            if (string.IsNullOrEmpty(door.Perforation))
                return new List<Operation>();

            return new List<Operation>
        {
            new Operation
            {
                Type = "HOLE",
                Diameter = 4,
                X = 300,
                Y = 300
            }
        };
        }
    }
}
