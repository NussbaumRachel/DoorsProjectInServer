using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CheckController : Controller
    {

        IBl Bl;
        public CheckController(IBl bl)
        {
            Bl = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public Task<List<BlCheck>> getAllChecks()
        {
            return Bl.checks.GetAll();
        }
        [HttpGet]
        public BlCheck getCheckById(int id)
        {
            return Bl.checks.Get(id);
        }
        [HttpGet]
        [Route("GetChecks")]
        public Task<List<BlCheck>> getByKey(String k)
        {
            return Bl.checks.GetByKey(k);
        }
        [HttpPost]
        [Route("Add")]
        public Boolean AddCheck(BlCheck newCheck)
        {

            Bl.checks.Create(newCheck);
            return true;
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Boolean> deleteCheck(BlCheck NewCheck)
        {
            return Bl.checks.Delete(NewCheck);

        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Boolean> deleteCheckById(int id)
        {
            return Bl.checks.DeleteById(id);

        }


    }

}
