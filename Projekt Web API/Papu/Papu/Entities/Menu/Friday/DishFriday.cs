namespace Papu.Entities
{
    public class DishFriday
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int FridayId { get; set; }
        public Friday Friday { get; set; }
    }
}
