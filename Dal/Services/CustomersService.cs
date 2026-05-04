using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

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
        
        public void Update(Customer item) { }
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
