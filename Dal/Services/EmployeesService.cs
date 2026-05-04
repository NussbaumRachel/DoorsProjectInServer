using Dal.Api;
using Dal.Models;
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
