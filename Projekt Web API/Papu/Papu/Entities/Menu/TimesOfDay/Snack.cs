using System.Collections.Generic;

namespace Papu.Entities
{
    public class Snack
    {
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<SnackProduct> Products { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<SnackDish> Dishes { get; set; }

        public virtual Monday Monday { get; set; }
        public virtual Tuesday Tuesday { get; set; }
        public virtual Wednesday Wednesday { get; set; }
        public virtual Thursday Thursday { get; set; }
        public virtual Friday Friday { get; set; }
        public virtual Saturday Saturday { get; set; }
        public virtual Sunday Sunday { get; set; }
    }
}
