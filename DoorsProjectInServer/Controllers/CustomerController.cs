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
       
    }
}
