using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoorController : Controller
    {
        IBl bl;
        public DoorController (IBl bl)
        {
            this.bl = bl;
        }
        [HttpGet]
        [Route("GetAll")]
        public Task<List<BlDoor>> getAll()
        {
            return bl.doors.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public int AddDoor(BlDoor newDoor)
        {
           return bl.doors.Create(newDoor).Result;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<Boolean> deleteDoor(int id)
        {
            return bl.doors.Delete(id);

        }
    }
}
