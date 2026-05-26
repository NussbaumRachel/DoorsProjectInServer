using Azure.Core;
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (d == null)
            {
                var _mpfGenerator = new MpfGenerator();
                var _mpfFileService = new MpfFileService(Dal);
                // 3. יצירת MPF
                var mpfContent = _mpfGenerator.Generate(item);
                var id =  Dal.doors.Create(convertFromBlDoorToDaldoor(item));

                // 4. שמירת MPF
                await _mpfFileService.SaveAsync(
                    id,
                    mpfContent
                );

                return id;
            }
            return d.Id;
        }

        public bool Delete(BlDoor item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            // convert and ensure Id is preserved
            var dalDoor = convertFromBlDoorToDaldoor(item);
            dalDoor.Id = item.Id;
            // mark as archived
            dalDoor.StatusArchive = true;

            // perform regular update (no duplication) - call DAL async method synchronously
            Dal.doors.UpdateAsync(dalDoor).GetAwaiter().GetResult();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            // fetch existing DAL entity
            var dalDoor = await Dal.doors.Get(id);
            if (dalDoor == null)
                return false;
            if (string.IsNullOrWhiteSpace(dalDoor.TextFileForTheMachine))
            {
                return Dal.doors.Delete(id).GetAwaiter().GetResult();
            }
            else
            {
                // set archive status and perform a normal update (no duplication)
                dalDoor.StatusArchive = true;
            await Dal.doors.UpdateAsync(dalDoor);
            return true;
                 }
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
            //var fileName = Path.GetFileName(c.TextFileForTheMachine);
            //newDoor.TextFileForTheMachine =
            //c.TextFileForTheMachine != null
            //? $"https://localhost:5001/api/Doors/file?fileName={Uri.EscapeDataString(c.TextFileForTheMachine)}"
            //: null;
            //newDoor.TextFileForTheMachine = c.TextFileForTheMachine;
            newDoor.TextFileForTheMachine =
    !string.IsNullOrWhiteSpace(c.TextFileForTheMachine)
        ? $"https://localhost:7253/api/Door/file?fileName={Uri.EscapeDataString(Path.GetFileName(c.TextFileForTheMachine))}"
        : null;
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
            newDoor.StatusArchive = c.StatusArchive;
            newDoor.ImageUrl = c.ImageUrl;
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
            newDoor.StatusArchive = c.StatusArchive;
            newDoor.ImageUrl = c.ImageUrl;
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
