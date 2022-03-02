using System.Collections.Generic;

namespace Papu.Entities
{
    public class Lunch
    {
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchId { get; set; }

        public string LunchName { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<LunchProduct> Products { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<LunchDish> Dishes { get; set; }

        public virtual ICollection<Monday> Mondays { get; set; }

    }
}
