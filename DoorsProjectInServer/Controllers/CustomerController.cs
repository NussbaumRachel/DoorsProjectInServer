using Bl.Api;
using Bl.Models;
using Dal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : Controller
    {
        IBl Bl;
        public CustomerController(IBl bl)
        {
            this.Bl = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public Task<List<BlCustomer>> getAllCustomers()
        {
            return Bl.customers.GetAll();
        }
        //[Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("Add")]
        public  async Task<bool> AddCustomer(BlCustomer newCustomer)
        {
            return await Bl.customers.Create(newCustomer);
             
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateC(BlCustomer cust)
        {
            var id = await Bl.customers.UpdateAsync(cust);
            return Ok(new { id });
        }
        [HttpDelete]
        [Route("Delete")]
        public Task<bool> deleteEmp(string id)
        {
            return Bl.customers.Delete(id);
        }
    }
}
