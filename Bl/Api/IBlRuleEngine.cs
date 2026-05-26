using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;

namespace Bl.Api
{
    public interface IBlDoorRule
    {
        List<Operation> Apply(BlDoor door);
    }
}
