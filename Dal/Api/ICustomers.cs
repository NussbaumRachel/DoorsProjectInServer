using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface ICustomers
    : ICrud<Customer>
    {

        public Task<Customer> Get(string id);
        public void DeleteAll();
        public Task<bool> Create(Customer item);
        public  Task UpdateAsync(Customer item);
        public Task<bool> Delete(string id);

    }
}
