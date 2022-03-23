using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Breakfast
    {
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<BreakfastProduct> Products { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<BreakfastDish> Dishes { get; set; }

        //Twórca danego śniadania
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danego śniadania
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
