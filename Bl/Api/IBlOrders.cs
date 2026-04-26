using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlOrders : ICrud<BlOrder>
    {
        public BlOrder Get(int id);
        public Task UpdateAsync(BlOrder item);

    }
}
