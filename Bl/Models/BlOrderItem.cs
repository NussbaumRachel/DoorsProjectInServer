using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BlOrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public byte ItemType { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; } 

    }
}
