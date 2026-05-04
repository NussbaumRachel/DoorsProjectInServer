using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlOrderItems : ICrud<BlOrderItem>
    {
        public void Create(BlOrderItem item, int orderId);
        public BlOrderItem convertFromDalOrderItemToBlOrderItem(OrderItem oi);
        public OrderItem convertFromBlOrderItemToDalOrderItem(BlOrderItem oi);

    }
}
