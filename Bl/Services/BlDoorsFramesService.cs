
using Bl.Api;
using Bl.Models;
using Dal;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
//{
//    public class BlDoorsFramesService
//        : IBlDoorsFrames
//    {
//        public IDal Dal;
//        public BlDoorsFramesService(IDal dal)
//        {
//            this.Dal = dal;
//        }
//        public async Task<int> Create(BlDoorFrame item)
//        {
//            var allDoorFrames = await Dal.doorFrames.GetAll();

//            DoorFrame df = allDoorFrames.Find(df => convertFromDalDoorFrameToBlDoorFrame(df).Equals(item));

//            if (df == null)
//                return Dal.doorFrames.Create(convertFromBlDoorFrameToDalDoorFrame(item));

//            return df.Id;
//        }
//        public bool Delete(BlDoorFrame item)
//        {
//            throw new NotImplementedException();
//        }

//        public void DeleteAll()
//        {
//            throw new NotImplementedException();
//        }

//        public BlDoorFrame Get(int id)
//        {
//            return convertFromDalDoorFrameToBlDoorFrame(Dal.doorFrames.Get(id).Result);
//        }

//        public async Task<List<BlDoorFrame>> GetAll()
//        {
//            List<BlDoorFrame> l = new List<BlDoorFrame>();
//            Dal.doorFrames.GetAll().Result.ForEach(df => l.Add(convertFromDalDoorFrameToBlDoorFrame(df)));
//            return l;
//        }
//        public BlDoorFrame convertFromDalDoorFrameToBlDoorFrame(DoorFrame df)
//        {
//            BlDoorFrame newDf = new BlDoorFrame();
//            newDf.WallFrameThickness = df.WallFrameThickness;
//            newDf.Desc = df.Desc;
//            newDf.PerforationTypeForShoeing = df.PerforationTypeForShoeing;
//            newDf.Color = df.Color;
//            newDf.FramesHeightWithShutter = df.FramesHeightWithShutter;
//            newDf.Height = df.Height;
//            newDf.Width = df.Width;
//            newDf.Hinges = df.Hinges;
//            newDf.Id = df.Id;
//            newDf.Side = df.Side;
//            newDf.Notes = df.Notes;
//            newDf.Opening = df.Opening;
//            newDf.Perforation = df.Perforation;
//            newDf.Profile = df.Profile;
//            newDf.Price = df.Price;
//            return newDf;
//        }

//        public DoorFrame convertFromBlDoorFrameToDalDoorFrame(BlDoorFrame df)
//        {
//            DoorFrame newDf = new DoorFrame();
//            newDf.WallFrameThickness = df.WallFrameThickness;
//            newDf.Desc = df.Desc;
//            newDf.PerforationTypeForShoeing = df.PerforationTypeForShoeing;
//            newDf.Color = df.Color;
//            newDf.Opening = df.Opening;
//            newDf.FramesHeightWithShutter = df.FramesHeightWithShutter;
//            newDf.Height = df.Height;
//            newDf.Width = df.Width;
//            newDf.Hinges = df.Hinges;
//            //newDf.Id = df.Id;
//            newDf.Side = df.Side;
//            newDf.Notes = df.Notes;
//            newDf.Perforation = df.Perforation;
//            newDf.Profile = df.Profile;
//            newDf.Price = df.Price;

//            return newDf;
//        }
//        public void Update(BlDoorFrame item)
//        {
//            throw new NotImplementedException();
//        }
//        public async Task<int> UpdateDoorAsync(BlDoorFrame item)
//        {
//            if (item == null)
//                throw new ArgumentNullException(nameof(item));

//            var dalDoorFrame = convertFromBlDoorFrameToDalDoorFrame(item);

//            var isUsed = await IsDoorFrameInUse(item.Id);

//            if (isUsed)
//            {
//                // 🔥 יוצרים חדשה
//                return Dal.doorFrames.Create(dalDoorFrame);
//            }
//            else
//            {
//                // 🔥 עדכון רגיל
//                dalDoorFrame.Id = item.Id;
//                await Dal.doorFrames.UpdateAsync(dalDoorFrame);
//                return dalDoorFrame.Id;
//            }
//        }
//        public async Task<bool> IsDoorFrameInUse(int frameId)
//        {
//            return await Dal.orderItems.ExistsItemInOrders(frameId);
//        }
//        public bool Delete(int id)
//        {
//            Dal.doorFrames.Delete(id); return true;
//        }
//        void Api.ICrud<BlDoorFrame>.Create(BlDoorFrame item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}



//Bl\Services\BlDoorsFramesService.cs;
//using Bl.Api;
//using Bl.Models;
//using Dal;
//using Dal.Api;
//using Dal.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bl.Services
{
    public class BlDoorsFramesService
        : IBlDoorsFrames
    {
        public IDal Dal;
        public BlDoorsFramesService(IDal dal)
        {
            this.Dal = dal;
        }
        public async Task<int> Create(BlDoorFrame item)
        {
            var allDoorFrames = await Dal.doorFrames.GetAll();

            DoorFrame df = allDoorFrames.Find(df => convertFromDalDoorFrameToBlDoorFrame(df).Equals(item));

            if (df == null)
                return Dal.doorFrames.Create(convertFromBlDoorFrameToDalDoorFrame(item));

            return df.Id;
        }
        public bool Delete(BlDoorFrame item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            // convert and ensure Id is preserved
            var dalDoorFrame = convertFromBlDoorFrameToDalDoorFrame(item);
            dalDoorFrame.Id = item.Id;
            // mark as archived
            dalDoorFrame.StatusArchive = true;

            // perform regular update (no duplication) - call DAL async method synchronously
            Dal.doorFrames.UpdateAsync(dalDoorFrame).GetAwaiter().GetResult();
            return true;
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public BlDoorFrame Get(int id)
        {
            return convertFromDalDoorFrameToBlDoorFrame(Dal.doorFrames.Get(id).Result);
        }

        public async Task<List<BlDoorFrame>> GetAll()
        {
            List<BlDoorFrame> l = new List<BlDoorFrame>();
            Dal.doorFrames.GetAll().Result.ForEach(df => l.Add(convertFromDalDoorFrameToBlDoorFrame(df)));
            return l;
        }
        public BlDoorFrame convertFromDalDoorFrameToBlDoorFrame(DoorFrame df)
        {
            BlDoorFrame newDf = new BlDoorFrame();
            newDf.WallFrameThickness = df.WallFrameThickness;
            newDf.Desc = df.Desc;
            newDf.PerforationTypeForShoeing = df.PerforationTypeForShoeing;
            newDf.Color = df.Color;
            newDf.FramesHeightWithShutter = df.FramesHeightWithShutter;
            newDf.Height = df.Height;
            newDf.Width = df.Width;
            newDf.Hinges = df.Hinges;
            newDf.Id = df.Id;
            newDf.Side = df.Side;
            newDf.Notes = df.Notes;
            newDf.Opening = df.Opening;
            newDf.Perforation = df.Perforation;
            newDf.Profile = df.Profile;
            newDf.Price = df.Price;
            newDf.StatusArchive = df.StatusArchive;
            newDf.ImageUrl = df.ImageUrl;
            return newDf;
        }

        public DoorFrame convertFromBlDoorFrameToDalDoorFrame(BlDoorFrame df)
        {
            DoorFrame newDf = new DoorFrame();
            newDf.WallFrameThickness = df.WallFrameThickness;
            newDf.Desc = df.Desc;
            newDf.PerforationTypeForShoeing = df.PerforationTypeForShoeing;
            newDf.Color = df.Color;
            newDf.Opening = df.Opening;
            newDf.FramesHeightWithShutter = df.FramesHeightWithShutter;
            newDf.Height = df.Height;
            newDf.Width = df.Width;
            newDf.Hinges = df.Hinges;
            // Id is set by caller when needed (preserve explicit control for create vs update)
            newDf.Side = df.Side;
            newDf.Notes = df.Notes;
            newDf.Perforation = df.Perforation;
            newDf.Profile = df.Profile;
            newDf.Price = df.Price;
            newDf.StatusArchive = df.StatusArchive;
            newDf.ImageUrl = df.ImageUrl;
            return newDf;
        }
        public void Update(BlDoorFrame item)
        {
            throw new NotImplementedException();
        }
        public async Task<int> UpdateDoorAsync(BlDoorFrame item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var dalDoorFrame = convertFromBlDoorFrameToDalDoorFrame(item);

            var isUsed = await IsDoorFrameInUse(item.Id);

            if (isUsed)
            {
                // 🔥 יוצרים חדשה
                return Dal.doorFrames.Create(dalDoorFrame);
            }
            else
            {
                // 🔥 עדכון רגיל
                dalDoorFrame.Id = item.Id;
                await Dal.doorFrames.UpdateAsync(dalDoorFrame);
                return dalDoorFrame.Id;
            }
        }
        public async Task<bool> IsDoorFrameInUse(int frameId)
        {
            return await Dal.orderItems.ExistsItemInOrders(frameId);
        }
        public bool Delete(int id)
        {
            // fetch existing DAL entity
            var dalDoorFrame = Dal.doorFrames.Get(id).Result;
            if (dalDoorFrame == null)
                return false;
            // If there is no text-file link -> delete permanently; otherwise archive (update)
            if (string.IsNullOrWhiteSpace(dalDoorFrame.TextFileForTheMachine))
            {
                return Dal.doorFrames.Delete(id).GetAwaiter().GetResult();
            }
            else
            {
                // set archive status and perform a normal update (no duplication)
                dalDoorFrame.StatusArchive = true;
            Dal.doorFrames.UpdateAsync(dalDoorFrame).GetAwaiter().GetResult();
            return true;
                }
        }
        void Api.ICrud<BlDoorFrame>.Create(BlDoorFrame item)
        {
            throw new NotImplementedException();
        }
    }
}