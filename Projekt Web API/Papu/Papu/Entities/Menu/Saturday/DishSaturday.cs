namespace Papu.Entities
{
    public class DishSaturday
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int SaturdayId { get; set; }
        public Saturday Saturday { get; set; }
    }
}
