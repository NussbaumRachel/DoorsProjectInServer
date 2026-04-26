using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBl
    {
        public IBlCheck checks { get; }
        public IBlOrders orders { get; }
        public IBlCustomers customers { get; }
        public IBlDoors doors { get; }
        public IBlDoorsFrames doorsFrames { get; }

        public IBlOrderItems orderItems { get; }
    }
}
