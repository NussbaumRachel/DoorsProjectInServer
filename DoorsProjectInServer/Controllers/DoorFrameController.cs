using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoorFrameController : Controller
    {
        IBl bl;
        public DoorFrameController (IBl bl)
        {
            this.bl = bl;
        }
        [HttpGet]
        [Route("GetAll")]
        public Task<List<BlDoorFrame>> getAllDoorFrames()
        {
            return bl.doorsFrames.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public int AddDoorFrame(BlDoorFrame newDoorFrame)
        {

            return bl.doorsFrames.Create(newDoorFrame).Result;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<Boolean> deleteDoorFrame(int id)
        {
            return bl.doorsFrames.Delete(id);
        }
    }
}
