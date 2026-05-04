using Dal.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Dal.Models;
using Dal.Services;
using Bl.Api;
using Bl.Models;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IBl Bl;

        public OrderController(IBl bl)
        {
            this.Bl = bl;
        }
        [HttpGet]
        [Route("GetAll")]
        public Task<List<BlOrder>> getAllOrders()
        {
            return Bl.orders.GetAll();
        }
        [HttpGet]
        public BlOrder getOrderById(int id)
        {
            return Bl.orders.Get(id);
        }


        [HttpPost]
        [Route("Add")]
        public Boolean AddOrder(BlOrder newOrder)
        {
            Bl.orders.Create(newOrder);
            return true;
        }
        [HttpDelete]
        [Route("Delete")]
        public Boolean deleteOrder(BlOrder Order)
        {
            return Bl.orders.Delete(Order);

        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateOrderAsync(BlOrder order)
        {
            if (order == null)
                return BadRequest("Order is null");

            try
            {
                await Bl.orders.UpdateAsync(order);
                return Ok("Order updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("שגיאה בעדכון ההזמנה: " + ex.Message);
            }
        }

    }
}
