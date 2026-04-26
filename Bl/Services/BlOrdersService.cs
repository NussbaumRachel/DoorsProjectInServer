using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bl.Services
{
    public class BlOrdersService : IBlOrders
    {
        IDal Dal;
        IBlOrderItems oi;

        public BlOrdersService(IDal Dal, IBlOrderItems oi)
        {
            this.Dal = Dal;
            this.oi = oi;
        }

        public void Create(BlOrder item)
        {
            try
            {
                int ordId = Dal.orders.Create(convertFromBlOrderToDalOrder(item));
                item.orderItems.ForEach(i => oi.Create(i,ordId));
            }
            catch {
                throw new NullReferenceException("item is null");
            }
        }

        public bool Delete(BlOrder item)
        {

            return Dal.orders.Delete(convertFromBlOrderToDalOrder(item));

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public BlOrder Get(int id)
        {
            return convertFromDalOrderToBlOrder(Dal.orders.Get(id).Result);
        }

        public async Task<List<BlOrder>> GetAll()
        {
            List<BlOrder> l = new List<BlOrder>();
            Dal.orders.GetAll().Result.ForEach(o => l.Add(convertFromDalOrderToBlOrder(o)));
            return l;
        }
        public BlOrder convertFromDalOrderToBlOrder(Order o)
        {
            BlOrder newOrder = new BlOrder();
            newOrder.Id = o.Id;
            newOrder.CustId = o.CustId;
            newOrder.Street = o.Street;
            newOrder.ApartmentNum = o.ApartmentNum;
            newOrder.Notes = o.Notes;
            newOrder.CustName = o.CustName;
            newOrder.BuildingNum = o.BuildingNum;
            newOrder.DeliveryDate = o.DeliveryDate;
            newOrder.Floor = o.Floor;
            newOrder.Plot = o.Plot;
            newOrder.Price = o.Price;
            newOrder.Status = o.Status;
            newOrder.orderItems = getItems(o.Id);
            return newOrder;

        }
        public List<BlOrderItem> getItems(int oid)
        {
            List < BlOrderItem > l = new List < BlOrderItem >();
             Dal.orderItems.getByOrderId(oid).Result.ForEach(Oi =>
              l.Add(oi.convertFromDalOrderItemToBlOrderItem(Oi)));
            return l;
        }
        public Order convertFromBlOrderToDalOrder(BlOrder o)
        {
            Order newOrder = new Order();
            newOrder.Id = o.Id;
            newOrder.CustId = o.CustId;
            newOrder.Street = o.Street;
            newOrder.ApartmentNum = o.ApartmentNum;
            newOrder.Notes = o.Notes;
            newOrder.CustName = o.CustName;
            newOrder.BuildingNum = o.BuildingNum;
            newOrder.DeliveryDate = o.DeliveryDate;
            newOrder.Floor = o.Floor;
            newOrder.Plot = o.Plot;
            newOrder.Price = o.Price;
            newOrder.Status = o.Status;
            return newOrder;
        }



        public async Task UpdateAsync(BlOrder item)
        {
            if (item == null)
                throw new NullReferenceException("item is null");

            var dalOrder = convertFromBlOrderToDalOrder(item);
            dalOrder.OrderItems = item.orderItems.Select(i => oi.convertFromBlOrderItemToDalOrderItem(i)).ToList();

            await Dal.orders.UpdateAsync(dalOrder);
        }

        public void Update(BlOrder item)
        {
            throw new NotImplementedException();
        }
    }
}
