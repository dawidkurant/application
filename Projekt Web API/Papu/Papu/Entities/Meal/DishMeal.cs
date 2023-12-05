namespace Papu.Entities
{
    public class DishMeal
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
