using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlEmployees :ICrud<BlEmployee>
    {
        public  Task<bool> Create(BlEmployee item);
        public Task<int> UpdateEmployeeAsync(BlEmployee item);
        public Task<bool> Delete(int id);
        public Task<BlEmployee> Login(string name, string password);

    }
}
