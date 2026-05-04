using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IBl bl;
        public EmployeesController(IBl bl)
        {
            this.bl = bl;
        }
        [HttpGet]
        [Route("GetAll")]
        public Task<List<BlEmployee>> getAll()
        {
            return bl.employees.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public Task<bool> AddEmployee(BlEmployee newEmployee)
        {

            return bl.employees.Create(newEmployee);
        }
    }
}
