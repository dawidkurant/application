namespace Papu.Entities
{
    public class DishWednesday
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int WednesdayId { get; set; }
        public Wednesday Wednesday { get; set; }
    }
}
