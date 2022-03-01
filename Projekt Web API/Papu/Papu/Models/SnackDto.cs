using System.Collections.Generic;

namespace Papu.Models
{
    public class SnackDto
    {
        //Podstawowe informacje dotyczące podwieczorka dostępne dla klienta

        //Id podwieczorka
        public int SnackId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> Products { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> Dishes { get; set; }
    }
}
