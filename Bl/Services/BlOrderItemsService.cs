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
    public class BlOrderItemsService : IBlOrderItems
    {
        IDal Dal;
        public BlOrderItemsService(IDal Dal)
        {
            this.Dal = Dal;
        }

        public void Create(BlOrderItem item, int orderId)
        {
            item.OrderId = orderId;
            Dal.orderItems.Create(convertFromBlOrderItemToDalOrderItem(item));
        }

        public bool Delete(BlOrderItem item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<BlOrderItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(BlOrderItem item)
        {
            throw new NotImplementedException();
        }
        public OrderItem convertFromBlOrderItemToDalOrderItem(BlOrderItem oi)
        {
            OrderItem newOrderItem = new OrderItem();
            newOrderItem.Id = oi.Id;
            newOrderItem.OrderId = oi.OrderId;
            newOrderItem.ItemId = oi.ItemId;
            newOrderItem.Quantity = oi.Quantity;
            newOrderItem.ItemType = oi.ItemType;
            return newOrderItem;
        }

        public BlOrderItem convertFromDalOrderItemToBlOrderItem(OrderItem oi)
        {
            BlOrderItem newOrderItem = new BlOrderItem();
            newOrderItem.Id = oi.Id;
            newOrderItem.OrderId = oi.OrderId;
            newOrderItem.ItemId = oi.ItemId;
            newOrderItem.Quantity = oi.Quantity;
            newOrderItem.ItemType = oi.ItemType;
            return newOrderItem;
        }

        public void Create(BlOrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
