using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DoorsFramesService : IDoorsFrames

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
                db.DoorFrames.Add(item);
                db.SaveChanges();
                return item.Id;
            }
            catch
            {
                throw new Exception("המסגרת/משקוף שנסית להכניס אינו/ה תקין/נה");
            }
        }
        public async Task UpdateAsync(DoorFrame item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await using var transaction = await db.Database.BeginTransactionAsync();

            try
            {
                var existingDoorFrame = await db.DoorFrames
                    .FirstOrDefaultAsync(d => d.Id == item.Id);

                if (existingDoorFrame == null)
                    throw new Exception("המשקוף לא נמצא");

                // 🔹 עדכון חכם (EF Core mapping במקום שדה-שדה ידני)
                db.Entry(existingDoorFrame).CurrentValues.SetValues(item);

                // 🔹 אופציונלי: שמירה על שדות שלא רוצים שידרסו
                // למשל אם יש שדות מערכת:
                // db.Entry(existingDoor).Property(x => x.CreatedAt).IsModified = false;

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("שגיאה בעדכון המשקוף: " + ex.Message);
            }
        }
        public void Update(DoorFrame item) { }
        public bool Delete(DoorFrame item)
        {
            //try
            //{
            //    var df = GetAll().Result.Find(df => df.Id == item.Id);
            //    db.DoorFrames.Remove(df);
            //    db.SaveChanges();
            //    return true;
            //}
            //catch
            //{
                throw new ArgumentNullException("לא נמצאה הדלת המתאימה");
            //}
        }
        public void DeleteAll() { }
       
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
        public async Task<List<DoorFrame>> GetAll() { return db.DoorFrames.ToList(); }

        void ICrud<DoorFrame>.Create(DoorFrame item)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> Delete(int id)
        {
         try { 
            // fetch entity directly from DB
            var df = await db.DoorFrames.FirstOrDefaultAsync(d => d.Id == id);
            if (df == null)
                return false;          
                    db.DoorFrames.Remove(df);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה במחיקת/ארכיון המשקוף: " + ex.Message);
            }
        }
    }
}


        // Improved Delete by id: uses async EF methods, avoids .Result, handles archive vs permanent delete
       

       