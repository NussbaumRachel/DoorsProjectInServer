using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlDoors : ICrud<BlDoor>
    {
        public BlDoor Get(int id);
        public Task<int> Create(BlDoor item);//****
        public bool Delete(int id);


    }
}
