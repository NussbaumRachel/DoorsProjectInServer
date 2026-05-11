using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlDoorsFrames : ICrud<BlDoorFrame>
    {
        public BlDoorFrame Get(int id);
        public Task<int> Create(BlDoorFrame item);
        public bool Delete(int id);
        public Task<int> UpdateDoorAsync(BlDoorFrame item);

    }
}
