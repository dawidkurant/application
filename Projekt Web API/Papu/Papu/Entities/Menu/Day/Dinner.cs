using System.Collections.Generic;

namespace Papu.Entities
{
    public class Dinner
    {
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<DinnerProduct> Products { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DinnerDish> Dishes { get; set; }

    }
}
