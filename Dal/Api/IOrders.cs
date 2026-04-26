using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Dal.Api
{
    public interface IOrders : ICrud<Order>
       
    {
        public Task<Order> Get(int id);
        public void DeleteAll();
        public int Create(Order item);
        public  Task UpdateAsync(Order item);


    }
}
