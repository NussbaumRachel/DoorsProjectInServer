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
    public class BlCustomersService : IBlCustomers
    {
        public IDal Dal;
        public BlCustomersService(IDal dal)
        {
            this.Dal = dal;
        }
        public void Create(BlCustomer item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BlCustomer item)
        {
            throw new NotImplementedException();
            return true;
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public BlCustomer Get(string id)
        {
            return convertFromDalCustomerToBlCustomer(Dal.customers.Get(id).Result);
        }

        public async Task<List<BlCustomer>> GetAll()
        {
            List<BlCustomer> l = new List<BlCustomer>();
            Dal.customers.GetAll().Result.ForEach(c => l.Add(convertFromDalCustomerToBlCustomer(c)));
            return l;
        }
        public BlCustomer convertFromDalCustomerToBlCustomer(Customer c)
        {
            BlCustomer newCust = new BlCustomer();
            newCust.Id = c.Id;
            newCust.Name = c.Name;
            newCust.Notes = c.Notes;
            newCust.Address = c.Address;
            newCust.Cn = c.Cn;
            newCust.Phone = c.Phone;
            newCust.Email = c.Email;
            newCust.ContactPersonName = c.ContactPersonName;
            newCust.ContactPersonPhone = c.ContactPersonPhone;
            newCust.Status = c.Status;
            return newCust;

        }
        public void Update(BlCustomer item)
        {
            throw new NotImplementedException();
        }
    }
}
