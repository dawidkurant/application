using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class MenuDto
    {
        // Identyfikator jadłospisu 
        public int MenuId { get; set; }

        // Dni zawierające się w jadłospisie
        public virtual ICollection<DayMenu> Days { get; set; }
    }
}
