using System.Collections.Generic;

namespace Papu.Models
{
    public class SecondBreakfastDto
    {
        //Podstawowe informacje dotyczące drugiego śniadania dostępne dla klienta

        //Id drugiego śniadania
        public int SecondBreakfastId { get; set; }

        public string SecondBreakfastName { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> Products { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> Dishes { get; set; }
    }
}
