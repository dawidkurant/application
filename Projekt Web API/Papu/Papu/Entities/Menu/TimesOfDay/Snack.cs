using System.Collections.Generic;

namespace Papu.Entities
{
    public class Snack : TimesOfDay
    {
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<SnackProduct> Products { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<SnackDish> Dishes { get; set; }
    }
}
