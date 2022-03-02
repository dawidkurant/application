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

        public string BreakfastName { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<BreakfastProduct> Products { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<BreakfastDish> Dishes { get; set; }

        public virtual ICollection<Monday> Mondays { get; set; }



    }
}
