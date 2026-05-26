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
    public class FrameRule : IBlDoorRule
    {
        public List<Operation> Apply(BlDoor door)
        {
            if (door.Width == null || door.Height == null)
                return new List<Operation>();

            return new List<Operation>
        {
            new Operation { Type = "CUT", X = 0, Y = 0 },
            new Operation { Type = "CUT", X = (double)door.Width, Y = 0 },
            new Operation { Type = "CUT", X =(double) door.Width, Y = (double)door.Height },
            new Operation { Type = "CUT", X = 0, Y = (double)door.Height}
        };
        }
    }
}
