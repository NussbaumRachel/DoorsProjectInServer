using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IEmployee:ICrud<Employee>
    {
        public Task<Employee> Get(String pass);
        public bool Create(Employee item);
        public Task UpdateAsync(Employee item);
        public Task<bool> Delete(int id);


    }
}
