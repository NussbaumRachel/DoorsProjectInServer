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
    public class HingesRule : IBlDoorRule
    {
        public List<Operation> Apply(BlDoor door)
        {
            var ops = new List<Operation>();

            if (door.Hinges == null || door.Hinges <= 0)
                return ops;

            for (int i = 0; i < door.Hinges; i++)
            {
                ops.Add(new Operation
                {
                    Type = "HOLE",
                    Diameter = 3.5,
                    X = 50,
                    Y = 150 + (i * 200)
                });
            }

            return ops;
        }
    }
}
