using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
namespace Bl.Api
{
    public interface IBlCheck:ICrud<BlCheck>
    {
        public BlCheck Get(int id);

        public Task<List<BlCheck>> GetByKey(String key);
        public bool DeleteById(int id);

    }
}