using Bl.Api;
using Bl.Models;
// Add the following using directive:
using Dal; // <-- Add this line if AppDbContext is in the Dal namespace
using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
/////////////////המיורקים - excel////////////////////

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IBl Bl;
        private readonly DbManager _context;
       private readonly ExcelService _excelService;
        public OrderController(IBl bl
            , DbManager context
            , ExcelService excelService
            )
        {
           _context = context;
            _excelService = excelService;
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

        ///////////////excel/////////////////////

        [HttpGet("export-excel")]
        public IActionResult ExportExcel()
        {
            var orders = _context.Orders.ToList();
                
                

            var fileBytes = _excelService.GenerateOrdersExcel((List<Dal.Models.Order>)orders);

            return File(
                fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"orders_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            );
        }

    }
}











