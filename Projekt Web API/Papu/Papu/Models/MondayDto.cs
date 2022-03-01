using System.Collections.Generic;

namespace Papu.Models
{
    public class MondayDto
    {
        //Podstawowe informacje dotyczące poniedziałku dostępne dla klienta

        //Id poniedziałku
        public int MondayId { get; set; }

        //Śniadanie wchodzące w skład poniedziałku
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> BreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> BreakfastDishes { get; set; }
    }
}
