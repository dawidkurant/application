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

        //Twórca danej kolacji
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danej kolacji
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
