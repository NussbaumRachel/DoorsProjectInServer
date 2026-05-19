using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bl.Services

{
    public class BlDoorsService
        : IBlDoors
    {
        IDal Dal;
        public BlDoorsService(IDal Dal)
        {
            this.Dal = Dal;
        }
        public async Task<int> Create(BlDoor item)
        {
            var allDoors = await Dal.doors.GetAll();

            Door d = allDoors.Find(d => convertFromDalDoorToBldoor(d).Equals(item));

            if (d == null) {
                 return Dal.doors.Create(convertFromBlDoorToDaldoor(item));

            }
                            return d.Id;
        }

        public bool Delete(BlDoor item)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            return Dal.doors.Delete(id);
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public BlDoor Get(int id)
        {
            return convertFromDalDoorToBldoor(Dal.doors.Get(id).Result);
        }

        public async Task<List<BlDoor>> GetAll()
        {
            List<BlDoor> l = new List<BlDoor>();
            Dal.doors.GetAll().Result.ForEach(d => l.Add(convertFromDalDoorToBldoor(d)));
            return l;
        }

        public BlDoor convertFromDalDoorToBldoor(Door c)
        {
            BlDoor newDoor = new BlDoor();
            newDoor.Id = c.Id;
            newDoor.Color = c.Color;
            newDoor.InternalLayoutLength = c.InternalLayoutLength;
            newDoor.ExternalLayoutLength = c.ExternalLayoutLength;
            newDoor.InternalLayoutWidth = c.InternalLayoutWidth;
            newDoor.ExternalLayoutWidth = c.ExternalLayoutWidth;
            newDoor.Finishing = c.Finishing;
            newDoor.Opening = c.Opening;
            newDoor.ShoeingC = c.ShoeingC;
            newDoor.ShoeingB = c.ShoeingB;
            newDoor.ShoeingA = c.ShoeingA;
            newDoor.Notes = c.Notes;
            newDoor.TextFileForTheMachine = c.TextFileForTheMachine;
            newDoor.Height = c.Height;
            newDoor.Width = c.Width;
            newDoor.Leaf = c.Leaf;
            newDoor.Hinges = c.Hinges;
            newDoor.Perforation = c.Perforation;
            newDoor.PerforationTypeForShoeing = c.PerforationTypeForShoeing;
            newDoor.Side = c.Side;
            newDoor.Skylight = c.Skylight;
            newDoor.Type = c.Type;
            newDoor.Price = c.Price;
            return newDoor;
        }

        public Door convertFromBlDoorToDaldoor(BlDoor c)
        {
            Door newDoor = new Door();
            newDoor.Color = c.Color;
            newDoor.InternalLayoutLength = c.InternalLayoutLength;
            newDoor.ExternalLayoutLength = c.ExternalLayoutLength;
            newDoor.InternalLayoutWidth = c.InternalLayoutWidth;
            newDoor.ExternalLayoutWidth = c.ExternalLayoutWidth;
            newDoor.Finishing = c.Finishing;
            newDoor.Opening = c.Opening;
            newDoor.ShoeingC = c.ShoeingC;
            newDoor.ShoeingB = c.ShoeingB;
            newDoor.ShoeingA = c.ShoeingA;
            newDoor.Notes = c.Notes;
            newDoor.TextFileForTheMachine = c.TextFileForTheMachine;
            newDoor.Height = c.Height;
            newDoor.Width = c.Width;
            newDoor.Leaf = c.Leaf;
            newDoor.Hinges = c.Hinges;
            newDoor.Perforation = c.Perforation;
            newDoor.PerforationTypeForShoeing = c.PerforationTypeForShoeing;
            newDoor.Side = c.Side;
            newDoor.Skylight = c.Skylight;
            newDoor.Type = c.Type;
            newDoor.Price = c.Price;
            return newDoor;
        }
        public async Task<int> UpdateDoorAsync(BlDoor item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var dalDoor = convertFromBlDoorToDaldoor(item);

            var isUsed = await IsDoorInUse(item.Id);

            if (isUsed)
            {
                // 🔥 יוצרים חדשה
                return Dal.doors.Create(dalDoor);
            }
            else
            {
                // 🔥 עדכון רגיל
                dalDoor.Id = item.Id;
                await Dal.doors.UpdateAsync(dalDoor);
                return dalDoor.Id;
            }
        }
        public async Task<bool> IsDoorInUse(int doorId)
        {
            return await Dal.orderItems.ExistsItemInOrders(doorId);
        }
        public async Task<string> UploadDoorFileAsync(int doorId, IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("לא נבחר קובץ");

            // שמירה פיזית של הקובץ
            var filePath = await Dal.doors.SaveDoorFileAsync(doorId, file);

            // עדכון הדלת במאגר
            await Dal.doors.UpdateDoorFilePathAsync(doorId, filePath);

            return filePath;
        }
        void Api.ICrud<BlDoor>.Create(BlDoor item)
        {
            throw new NotImplementedException();
        }

        void Api.ICrud<BlDoor>.Update(BlDoor item)
        {
            throw new NotImplementedException();
        }

        public Task Update(BlDoor item)
        {
            throw new NotImplementedException();
        }
    }
}
