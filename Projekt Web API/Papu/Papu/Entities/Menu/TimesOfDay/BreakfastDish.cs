using System.Text.Json.Serialization;

namespace Papu.Entities
{
    public class BreakfastDish
    {
        public int BreakfastId { get; set; }
        public Breakfast Breakfast { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
