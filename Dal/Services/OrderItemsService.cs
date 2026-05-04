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
    public class OrderItemsService : IOrderItems
    {
        DbManager dbManager;
        public OrderItemsService(DbManager dbm)
        {
            dbManager = dbm;
        }
        public void Create(OrderItem item)
        {
            if (item == null)
            {

                throw new ArgumentNullException("item");
            }
            try
            {
                dbManager.OrderItems.Add(item);
                dbManager.SaveChanges();
            }
            catch
            {
                throw new Exception("הפריט שנסית להכניס אינו תקין");
            }
        }

        public bool Delete(OrderItem item)
        {
            try
            {
                dbManager.OrderItems.Remove(item);
                dbManager.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצא הפריט המתאים");
            }
        }

        //public async Task<List<OrderItem>> GetAll()
        //{
        //   return dbManager.OrderItems.Include(i => i.Order).ToList();
        //}
        public async Task<List<OrderItem>> GetAll() => dbManager.OrderItems.ToList();

        public async Task<List<OrderItem>> getByOrderId(int ordId) => GetAll().Result.FindAll(oi => oi.OrderId == ordId);

        public async Task<OrderItem> get(int id)
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




        public void Update(OrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
