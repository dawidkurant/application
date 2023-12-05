namespace Papu.Entities
{
    public class ProductMeal
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
