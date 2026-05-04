using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Dal.Services
{
    public class DoorsService : IDoors

    {
        DbManager db;
        public DoorsService(DbManager db)
        {
            this.db = db;
        }
        public int Create(Door item)
        {
            if (item == null)
            {

                throw new ArgumentNullException("item");
            }
            try
            {
                db.Doors.Add(item);
                db.SaveChanges();
                return item.Id;
            }
            catch
            {
                throw new Exception("הדלת שנסית להכניס אינה תקינה");
            }
        }
        public void Update(Door item) { }
        public bool Delete(Door item)
        {
            try
            {
                var d = GetAll().Result.Find(d => d.Id == item.Id);
                db.Doors.Remove(d);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצאה הדלת המתאימה");
            }
        }
        public async Task<bool> Delete(int id)
        {

            var ch = GetAll().Result.Find(c => c.Id == id);
            try
            {
                db.Doors.Remove(ch);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצאה הדלת המתאימה");

            }

        }
        public void DeleteAll() { }
        public async Task<Door> Get(int id)
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
        public async Task<List<Door>> GetAll() => db.Doors.ToList();

        void ICrud<Door>.Create(Door item)
        {
            throw new NotImplementedException();
        }
    }
}
