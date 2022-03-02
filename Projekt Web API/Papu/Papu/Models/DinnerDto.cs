using System.Collections.Generic;

namespace Papu.Models
{
    public class DinnerDto
    {
        //Podstawowe informacje dotyczące kolacji dostępne dla klienta

        //Id kolacji
        public int DinnerId { get; set; }

        public string DinnerName { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> Products { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> Dishes { get; set; }
    }
}
