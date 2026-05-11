using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Dal.Api
{
    public interface IDoorsFrames
        : ICrud<DoorFrame>
    {
        public Task<DoorFrame> Get(int id);
        public void DeleteAll();
        public int Create(DoorFrame item);
        public Task<bool> Delete(int id);
        public  Task UpdateAsync(DoorFrame item);


    }
}
