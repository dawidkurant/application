using Newtonsoft.Json;
using System.Collections.Generic;

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

    }
}
