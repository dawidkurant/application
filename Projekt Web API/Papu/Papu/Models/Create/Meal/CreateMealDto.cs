using Papu.Entities;

namespace Papu.Models
{
    public class CreateMealDto
    {
        // Pora dnia
        public MealType MealType { get; set; }

        // Dania zawierające się w porze dnia
        public int[] DishId { get; set; }

        // Produkty zawierające się w porze dnia
        public int[] ProductId { get; set; }
    }
}
