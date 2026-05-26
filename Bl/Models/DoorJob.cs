using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class DoorJob
    {
        
            // Basic geometry
            public string JobId { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public double Thickness { get; set; }

            // Material
            public string Material { get; set; }
            public double MaterialThickness { get; set; }

            // Machine setup
            public string MachineType { get; set; }
            public List<int> Clamps { get; set; }

            public double SheetWidth { get; set; }
            public double SheetHeight { get; set; }
            public double SheetThickness { get; set; }

            // Core geometry operations
            public List<Operation> Operations { get; set; }

            // Metadata
            public string DoorType { get; set; }
            public string Model { get; set; }
            public string Customer { get; set; }
            public int Quantity { get; set; }

            public DateTime CreatedAt { get; set; }
        
    }
}
