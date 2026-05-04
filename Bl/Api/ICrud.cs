using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface ICrud<T>
    {
        public void Create(T item);
        public void Update(T item);
        public bool Delete(T item);
        public void DeleteAll();
        public Task<List<T>> GetAll();
    }
}
