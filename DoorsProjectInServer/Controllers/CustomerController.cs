using Bl.Api;
using Bl.Models;
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
    }  
}
