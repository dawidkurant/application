using System.Collections.Generic;

namespace Papu.Entities
{
    public class SecondBreakfast
    {
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<SecondBreakfastProduct> Products { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<SecondBreakfastDish> Dishes { get; set; }

        public virtual Monday Monday { get; set; }
        public virtual Tuesday Tuesday { get; set; }
        public virtual Wednesday Wednesday { get; set; }
        public virtual Thursday Thursday { get; set; }
        public virtual Friday Friday { get; set; }
        public virtual Saturday Saturday { get; set; }
        public virtual Sunday Sunday { get; set; }

    }
}
