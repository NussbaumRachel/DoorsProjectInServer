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
    public class EmployeesService : IEmployee
    {
        DbManager db;
        public EmployeesService(DbManager db)
        {
            this.db = db;
        }
        public bool Create(Employee item)
        {
            if (item == null)
            {

                throw new ArgumentNullException("item");
            }
            try
            {
                db.Employees.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("הלקוח שנסית להכניס אינו תקין");
            }
        }
        public async Task UpdateAsync(Employee item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await using var transaction = await db.Database.BeginTransactionAsync();

            try
            {
                var existingEmployee = await db.Employees
                    .FirstOrDefaultAsync(d => d.Id == item.Id);

                if (existingEmployee == null)
                    throw new Exception("הדלת לא נמצאה");

                // 🔹 עדכון חכם (EF Core mapping במקום שדה-שדה ידני)
                db.Entry(existingEmployee).CurrentValues.SetValues(item);

                // 🔹 אופציונלי: שמירה על שדות שלא רוצים שידרסו
                // למשל אם יש שדות מערכת:
                // db.Entry(existingDoor).Property(x => x.CreatedAt).IsModified = false;

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("שגיאה בעדכון העובד: " + ex.Message);
            }
        }
        public bool Delete(Employee item)
        {
            try
            {
                var e = GetAll().Result.Find(e => e.Id == item.Id);
                db.Employees.Remove(e);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצא העובד המתאים");
            }
        }

        public async Task<List<Employee>> GetAll() => db.Employees.ToList();
        public async Task<bool> Delete(int id)
        {

            var ch = GetAll().Result.Find(c => c.Id == id);
            try
            {
                db.Employees.Remove(ch);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצאה העובד המתאים");

            }

        }
      
        public async Task<Employee> Get(String pass)
        {
            try
            {
                return GetAll().Result.Find(o => o.Password == pass);
            }
            catch
            {
                throw new ArgumentNullException("not found!");
            }
        }
        public void Update(Employee item)
        {
            throw new NotImplementedException();
        }

        void ICrud<Employee>.Create(Employee item)
        {
            throw new NotImplementedException();
        }

        
    }
}
