using System.Collections.Generic;

namespace Papu.Entities
{
    // Jadłospis
    public class Menu
    {
        // Identyfikator jadłospisu 
        public int MenuId { get; set; }

        // Dni zawierające się w jadłospisie
        public virtual ICollection<DayMenu> Days { get; set; }

        //Twórca danego jadłospisu
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danego jadłospisu
        public virtual User CreatedBy { get; set; }
    }
}
