using Bl.Api;
using Bl.Models;
using Bl.Services;
using Helpers;
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
        public Task<bool> deleteDoor(int id)
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
        //[HttpGet("file")]
        //public IActionResult GetFile([FromQuery] string fileName)
        //{
        //    var folderPath = @"D:\C# METZADA\DoorsProjectInServer\DoorFiles";

        //    var fullPath = Path.Combine(folderPath, fileName);

        //    if (!System.IO.File.Exists(fullPath))
        //        return NotFound();

        //    var bytes = System.IO.File.ReadAllBytes(fullPath);

        //    var contentType =FileHelper.GetContentType(fileName);
        //    return File(bytes, contentType, fileName);
        //}

        [HttpPost]
        [Route("createMpf")]
        public IActionResult createMpf(BlDoor job)
        {
            var generator = new MpfGenerator();
            var mpf = generator.Generate(job);
            return Ok(mpf);

        }

        [HttpGet("file")]
        public IActionResult GetFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DoorFiles", fileName);

            if (!System.IO.File.Exists(path))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(path);

            return File(fileBytes, "application/octet-stream", fileName);
        }
    }
}
