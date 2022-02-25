namespace Papu.Entities
{
    public class DishTuesday
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int TuesdayId { get; set; }
        public Tuesday Tuesday { get; set; }
    }
}
