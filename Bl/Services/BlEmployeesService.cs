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
    public class BlEmployeesService : IBlEmployees
    {

        public IDal Dal;
        public BlEmployeesService(IDal dal)
        {
            this.Dal = dal;
        }
        public async Task<bool> Create(BlEmployee item)
        {
            var allEmp = await Dal.employees.GetAll();

            Employee d = allEmp.Find(d => convertFromDalEmpToBlEmp(d).Equals(item));

            if (d != null)
                return false;


            return  Dal.employees.Create(convertFromBlEmpToDalEmp(item));

        }

        public bool Delete(BlEmployee item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BlEmployee>> GetAll()
        {
            List<BlEmployee> l = new List<BlEmployee>();
            Dal.employees.GetAll().Result.ForEach(d => l.Add(convertFromDalEmpToBlEmp(d)));
            return l;
        }

        public void Update(BlEmployee item)
        {
            throw new NotImplementedException();
        }
        public BlEmployee convertFromDalEmpToBlEmp(Employee em)
        {
            BlEmployee emp = new BlEmployee()
            {
                Name = em.Name,
                Address = em.Address,
                BirthDate = em.BirthDate,
                Email = em.Email,
                Id = em.Id,
                Password = em.Password,
                Phone1 = em.Phone1,
                Phone2 = em.Phone2,
                Status = em.Status
            };
            return emp;
        }

        public Employee convertFromBlEmpToDalEmp(BlEmployee em)
        {
           Employee emp = new Employee()
            {
                Name = em.Name,
                Address = em.Address,
                BirthDate = em.BirthDate,
                Email = em.Email,
                Id = em.Id,
                Password = em.Password,
                Phone1 = em.Phone1,
                Phone2 = em.Phone2,
                Status = em.Status
            };
            return emp;
        }

        void Api.ICrud<BlEmployee>.Create(BlEmployee item)
        {
            throw new NotImplementedException();
        }
    }
}
