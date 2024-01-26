using System.Collections.Generic;

namespace Papu.Entities
{
    public class DayMenu
    {
        // Identyfikator dnia
        public int DayMenuId { get; set; }

        // Dzień
        public DayOfWeek DayOfWeek { get; set; }

        // Pory dnia zawierające się w dniu
        public virtual ICollection<Meal> Meals { get; set; }

        // Zmienna reprezentująca jadłospis
        public virtual Menu Menu { get; set; }

        //Twórca danego dnia
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danego dnia
        public virtual User CreatedBy { get; set; }
    }
}
