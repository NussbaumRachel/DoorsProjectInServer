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
        public async Task<bool> Create(BlCustomer item)
        {
           
            return await Dal.customers.Create(convertFromBlCustomerToDalCustomer(item));
           
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
            BlCustomer newCust = new BlCustomer()
            {
            Id = c.Id,
            Name = c.Name,
            Notes = c.Notes,
            Address = c.Address,
            Cn = c.Cn,
            Phone = c.Phone,
            Email = c.Email,
            ContactPersonName = c.ContactPersonName,
            ContactPersonPhone = c.ContactPersonPhone,
            Status = c.Status
            };
            return newCust;

        }
        public Customer convertFromBlCustomerToDalCustomer(BlCustomer c)
        {
            Customer newCust = new Customer() { 
            Id = c.Id,
            Name = c.Name,
            Notes = c.Notes,
            Address = c.Address,
            Cn = c.Cn,
            Phone = c.Phone,
            Email = c.Email,
            ContactPersonName = c.ContactPersonName,
            ContactPersonPhone = c.ContactPersonPhone,
            Status = c.Status
            };
            return newCust;
        }
        public void Update(BlCustomer item)
        {
            throw new NotImplementedException();
        }

        void Api.ICrud<BlCustomer>.Create(BlCustomer item)
        {
            throw new NotImplementedException();
        }
    }
}
