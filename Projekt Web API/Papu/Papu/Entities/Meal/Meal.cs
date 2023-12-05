using System.Collections.Generic;

namespace Papu.Entities
{
    // Pora dnia
    public class Meal
    {
        // Identyfkator pory dnia
        public int MealId { get; set; }

        // Pora dnia
        public MealType MealType { get; set; }

        // Dania zawierające się w porze dnia
        public virtual ICollection<DishMeal> DishMeals { get; set; }

        // Produkty zawierające się w porze dnia
        public virtual ICollection<ProductMeal> ProductMeals { get; set; }

        // Zmienna reprezentująca dzień
        public virtual DayMenu DayMenu { get; set; }

        //Twórca danej pory dnia
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danej pory dnia
        public virtual User CreatedBy { get; set; }
    }
}
