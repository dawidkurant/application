using System.Collections.Generic;

namespace Papu.Models
{
    public class LunchDto
    {
        //Podstawowe informacje dotyczące obiadu dostępne dla klienta

        //Id obiadu
        public int LunchId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> Products { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> Dishes { get; set; }
    }
}
