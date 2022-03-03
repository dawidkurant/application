namespace Papu.Entities
{
    public class SecondBreakfastDish
    {
        public int SecondBreakfastId { get; set; }
        public SecondBreakfast SecondBreakfast { get; set; }


        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
