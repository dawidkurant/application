using System.Collections.Generic;

namespace Papu.Entities
{
    public class Snack
    {
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackId { get; set; }

        public string SnackName { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<SnackProduct> Products { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<SnackDish> Dishes { get; set; }

        public virtual ICollection<Monday> Mondays { get; set; }


    }
}
