using Newtonsoft.Json;
using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class BreakfastDto
    {
        //Podstawowe informacje dotyczące śniadania dostępne dla klienta

        //Id śniadania
        public int BreakfastId { get; set; }

        public string BreakfastName { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> Products { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> Dishes { get; set; }

    }
}
