using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class CheckService
        : ICheck
    {
        DbManager db;
        public CheckService(DbManager db)
        {
            this.db = db;
        }
        public void Create(Check item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            try
            {

                db.Checks.Add(item);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("הערך אינו תקין");
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var ch = GetAll().Result.Find(c => c.Id == id);
                db.Checks.Remove(ch);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצא הצ'ק המתאים");
            }
        }
        public bool Delete(Check item)
        {
            try
            {
                var ch = GetAll().Result.Find(c => c.Id == item.Id);
                db.Checks.Remove(ch);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצא הצ'ק המתאים");
            }
        }

        public void DeleteAll(List<Check> l)
        {
            l.ForEach(c => Delete(c));
        }





        public async Task<Check> Get(int id)
        {
            try
            {
                return GetAll().Result.Find(c => c.Id == id);
            }
            catch
            {
                throw new ArgumentNullException("not found!");
            }
        }

        public async Task<List<Check>> GetAll()
        {
          return db.Checks.ToList();
        }

        public void Update(Check item)
        {
            if (item != null)
            {
                Task<Check> ch = Get(item.Id);
                //try
                //{
                //    ch = item;
                //} 

            }
        }
    }
}
