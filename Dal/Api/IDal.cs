using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        public ICheck checks { get; }
        public IOrders orders { get; }
        public IEmployee employees { get; }

        public ICustomers customers { get; }
        public IDoors doors { get; }
        public IDoorsFrames doorFrames { get; }

        public IOrderItems orderItems { get; }
    }
}
