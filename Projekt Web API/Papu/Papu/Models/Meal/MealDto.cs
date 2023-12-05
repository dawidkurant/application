using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class MealDto
    {
        // Identyfkator pory dnia
        public int MealId { get; set; }

        // Pora dnia
        public MealType MealType { get; set; }

        // Dania zawierające się w porze dnia
        public virtual ICollection<DishDto> Dishes { get; set; }

        // Produkty zawierające się w porze dnia
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
