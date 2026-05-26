using Dal.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDoors : ICrud<Door>

    {
        public Task<Door> Get(int id);
        public void DeleteAll();
        public int Create(Door item);
        public Task<bool> Delete(int id);
        public Task UpdateAsync(Door item);
        public Task UpdateDoorFilePathAsync(int doorId, string filePath);
        public Task<string> SaveDoorFileAsync(int doorId, IFormFile file);
        public string createFilePath(int doorId);


    }
}
