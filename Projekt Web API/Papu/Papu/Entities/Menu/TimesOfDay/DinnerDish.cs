namespace Papu.Entities
{
    public class DinnerDish
    {
        public int DinnerId { get; set; }
        public Dinner Dinner { get; set; }


        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
