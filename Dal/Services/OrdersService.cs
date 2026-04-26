using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class OrdersService
        : IOrders
    {
        DbManager db;
        public OrdersService(DbManager db)
        {
            this.db = db;
        }
        public int Create(Order item)
        {
            if (item == null)
            {

                throw new ArgumentNullException("item");
            }
            try
            {
                db.Orders.Add(item);
                db.SaveChanges();
                return item.Id;
            }
            catch
            {
                throw new Exception("ההזמנה שנסית להכניס אינה תקינה");
            }
        }
        public async Task UpdateAsync(Order item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                var existingOrder = await db.Orders
                                            .Include(o => o.OrderItems)
                                            .FirstOrDefaultAsync(o => o.Id == item.Id);

                if (existingOrder == null)
                    throw new Exception("ההזמנה לא נמצאה");

                existingOrder.Floor = item.Floor;
                existingOrder.DeliveryDate = item.DeliveryDate;
                existingOrder.Price = item.Price;
                existingOrder.Plot = item.Plot;
                existingOrder.Street = item.Street;
                existingOrder.Status = item.Status;
                existingOrder.Notes = item.Notes;
                existingOrder.CustName = item.CustName;
                existingOrder.CustId = item.CustId;
                existingOrder.BuildingNum = item.BuildingNum;
                existingOrder.ApartmentNum = item.ApartmentNum;

                db.OrderItems.RemoveRange(existingOrder.OrderItems);

                if (item.OrderItems != null && item.OrderItems.Count > 0)
                {
                    foreach (var oi in item.OrderItems)
                    {
                        oi.OrderId = existingOrder.Id;
                        await db.OrderItems.AddAsync(oi);
                    }
                }

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("שגיאה בעדכון ההזמנה: " + ex.Message);
            }
        }
        public bool Delete(Order item)
        {
            try
            {
                //var order = GetAll().Result.Find(o => o.Id == item.Id);
                db.Orders.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new ArgumentNullException("לא נמצאה ההזמנה המתאימה");
            }
        }
        public void DeleteAll()
        {

        }
        public async Task<Order> Get(int id)
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
        public async Task<List<Order>> GetAll() => db.Orders.ToList();



        public async Task<List<Order>> getAllItems() => db.Orders.Include(i => i.OrderItems).ToList();

        void ICrud<Order>.Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
