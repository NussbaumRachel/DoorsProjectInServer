using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
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
            throw new NotImplementedException();
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
            newDf.Id = df.Id;
            newDf.Side = df.Side;
            newDf.Notes = df.Notes;
            newDf.Perforation = df.Perforation;
            newDf.Profile = df.Profile;

            return newDf;
        }
        public void Update(BlDoorFrame item)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            Dal.doorFrames.Delete(id); return true;
        }
        void Api.ICrud<BlDoorFrame>.Create(BlDoorFrame item)
        {
            throw new NotImplementedException();
        }
    }
}
