using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface ICrud<T>
    {
        public void Create(T item);
        public void Update(T item);
        public bool Delete(T item);

        public Task<List<T>> GetAll();
    }
}
