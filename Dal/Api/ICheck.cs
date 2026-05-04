using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
namespace Dal.Api
{
    public interface ICheck : ICrud<Check>
    {
        public Task<Check> Get(int id);
        public void DeleteAll(List<Check> l);
        public bool Delete(int id);

    }
}
