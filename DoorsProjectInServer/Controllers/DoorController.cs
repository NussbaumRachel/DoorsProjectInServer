using Bl.Api;
using Bl.Models;
using Dal.Api;
using Microsoft.AspNetCore.Mvc;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoorController : Controller
    {
        IBl bl;
        public DoorController(IBl bl)
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
     
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateDoor(BlDoor door)
        {
            var id = await bl.doors.UpdateDoorAsync(door);
            return Ok(new { id });
        }
        [HttpPost("UploadDoorFile/{doorId}")]
        public async Task<IActionResult> UploadDoorFile(int doorId, IFormFile file)
        {
            try
            {
                var path = await bl.doors.UploadDoorFileAsync(doorId, file);
                return Ok(new { message = "הקובץ הועלה בהצלחה", path });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "שגיאה בהעלאת הקובץ: " + ex.Message });
            }
        }
    }
}
