using System.Collections.Generic;

namespace Papu.Entities
{
    public class Lunch
    {
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<LunchProduct> Products { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<LunchDish> Dishes { get; set; }

        //Twórca danego obiadu
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danego obiadu
        public virtual User CreatedBy { get; set; }
        public virtual Monday Monday { get; set; }
        public virtual Tuesday Tuesday { get; set; }
        public virtual Wednesday Wednesday { get; set; }
        public virtual Thursday Thursday { get; set; }
        public virtual Friday Friday { get; set; }
        public virtual Saturday Saturday { get; set; }
        public virtual Sunday Sunday { get; set; }

    }
}
