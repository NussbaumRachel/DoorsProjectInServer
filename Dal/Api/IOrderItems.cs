using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IOrderItems : ICrud<OrderItem>
    {
        public Task<List<OrderItem>> getByOrderId(int ordId);
        public Task<bool> Delete(OrderItem item);

    }
}
