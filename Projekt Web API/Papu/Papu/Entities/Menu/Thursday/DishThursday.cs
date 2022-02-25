namespace Papu.Entities
{
    public class DishThursday
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int ThursdayId { get; set; }
        public Thursday Thursday { get; set; }
    }
}
