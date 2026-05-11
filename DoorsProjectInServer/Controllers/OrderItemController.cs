using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IBl bl;
        public OrderItemController(IBl bl)
        {
            this.bl = bl;
        }   
            [HttpPost]
            [Route("Add")]
            public Boolean AddOrderItem(BlOrderItem newOrderItem)
            {
                bl.orderItems.Create(newOrderItem);
                return true;
        }
            [HttpDelete]
            [Route("Delete")]
            public Task<bool> deleteOrderItem(BlOrderItem OrderItem)
            {
                return bl.orderItems.Delete(OrderItem);
        }
        [HttpGet]
        [Route("GetAll")]
        public List<BlOrderItem> getAllOrderItems()
        {
            return bl.orderItems.GetAll();
        }
       

    }
}
