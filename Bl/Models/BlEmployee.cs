using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BlEmployee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? Status { get; set; }

        public string? Address { get; set; }

        public string? Phone1 { get; set; }

        public string? Phone2 { get; set; }

        public DateTime? BirthDate { get; set; }
    

    public bool Equals(BlEmployee e)
        {
            return Id.Equals(e.Id);
        }
    }
}
