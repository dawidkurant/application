using System.Collections.Generic;

namespace Papu.Entities
{
    public class Lunch : TimesOfDay
    {
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<LunchProduct> Products { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<LunchDish> Dishes { get; set; }
    }
}
