using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
        public async Task UpdateAsync(Door item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await using var transaction = await db.Database.BeginTransactionAsync();

            try
            {
                var existingDoor = await db.Doors
                    .FirstOrDefaultAsync(d => d.Id == item.Id);

                if (existingDoor == null)
                    throw new Exception("הדלת לא נמצאה");

                // 🔹 עדכון חכם (EF Core mapping במקום שדה-שדה ידני)
                db.Entry(existingDoor).CurrentValues.SetValues(item);

                // 🔹 אופציונלי: שמירה על שדות שלא רוצים שידרסו
                // למשל אם יש שדות מערכת:
                // db.Entry(existingDoor).Property(x => x.CreatedAt).IsModified = false;

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("שגיאה בעדכון הדלת: " + ex.Message);
            }
        }
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
            try
            {
                // fetch entity directly from DB
                var d = await db.Doors.FirstOrDefaultAsync(d => d.Id == id);
                if (d == null)
                    return false;
                db.Doors.Remove(d);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה במחיקת הדלת: " + ex.Message);
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

        public void Update(Door item)
        {
            throw new NotImplementedException();
        }
        public async Task<string> SaveDoorFileAsync(int doorId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("לא נבחר קובץ");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "DoorFiles");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, $"Door_{doorId}_{file.FileName}");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
        public async Task UpdateDoorFilePathAsync(int doorId, string filePath)
        {
            var door = await db.Doors.FirstOrDefaultAsync(d => d.Id == doorId);
            if (door == null) throw new Exception("הדלת לא נמצאה");

            door.TextFileForTheMachine = filePath;
            await db.SaveChangesAsync();
        }
    }
}
