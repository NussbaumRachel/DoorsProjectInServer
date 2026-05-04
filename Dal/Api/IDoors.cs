using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Dal.Api
{
    public interface IDoors : ICrud<Door>

    {
        public Task<Door> Get(int id);
        public void DeleteAll();
        public int Create(Door item);
        public Task<bool> Delete(int id);

    }
}
