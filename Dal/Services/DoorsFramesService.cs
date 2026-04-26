using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DoorsFramesService: IDoorsFrames
        
    {
        DbManager db;
        public DoorsFramesService(DbManager db)
        {
            this.db = db;
        }
        public int Create(DoorFrame item)
        {
            if (item == null)
            {

                throw new ArgumentNullException("item");
            }
            try
            {
                db.DoorFramesTables.Add(item);
                db.SaveChanges();
                return item.Id;
            }
            catch
            {
                throw new Exception("המסגרת/משקוף שנסית להכניס אינו/ה תקין/נה");
            }
        }
        public void Update(DoorFrame item) { }
        public bool Delete(DoorFrame item) {
            try
            {
                var df = GetAll().Result.Find(df => df.Id == item.Id);
                db.DoorFramesTables.Remove(df);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצאה הדלת המתאימה");
            }
        }
        public void DeleteAll() { }
        public async Task<bool> Delete(int id)
        {

            var ch = GetAll().Result.Find(c => c.Id == id);
            try
            {
                db.DoorFramesTables.Remove(ch);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצאה המשקוף המתאים");

            }

        }
        public async Task<DoorFrame> Get(int id)
        {
            try
            {
                return GetAll().Result.Find(o => o.Id == id);
            }
            catch
            {
                throw new ArgumentNullException("not found!");
            }
        }
        public async Task<List<DoorFrame>> GetAll() { return db.DoorFramesTables.ToList(); }

        void ICrud<DoorFrame>.Create(DoorFrame item)
        {
            throw new NotImplementedException();
        }
    }
}
