using Bl.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlDoors : ICrud<BlDoor>
    {
        public BlDoor Get(int id);
        public Task<int> Create(BlDoor item);//****
        public Task<bool> Delete(int id);
        public Task<int> UpdateDoorAsync(BlDoor item);
        public  Task<string> UploadDoorFileAsync(int doorId, IFormFile file);


    }
}
