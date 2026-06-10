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
    public class CustomersService : ICustomers
    {
        DbManager db;
        public CustomersService(DbManager db)
        {
            this.db = db;
        }
        public async Task<bool> Create(Customer item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            try
            {
                await db.Customers.AddAsync(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new Exception("Insert failed");
            }
        }
        public async Task UpdateAsync(Customer item)//////////////////////////////////////////
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await using var transaction = await db.Database.BeginTransactionAsync();

            try
            {
                var existingEmployee = await db.Customers
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
        public void Update(Customer item) { }


        public async Task<bool> Delete(string id)
        {

            var ch = GetAll().Result.Find(c => c.Id == id);
            try
            {
                db.Customers.Remove(ch);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצאה הלקוח המתאים");

            }

        }

        public bool Delete(Customer item)
        {
            return true;
            //try
            //{
            //    var c = GetAll().Result.Find(c => c.Id == item.Id);
            //    db.Customers.Remove(c);
            //    db.SaveChanges();
            //    return true;
            //}
            //catch
            //{
            //    throw new ArgumentNullException("לא נמצא הלקוח המתאים המתאים");
            //}
        }
        public void DeleteAll() { }
        public async Task<Customer> Get(string id)
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
        public async Task<List<Customer>> GetAll() { return db.Customers.ToList(); }

        void ICrud<Customer>.Create(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
