namespace Papu.Entities
{ 
    public class DishSunday
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int SundayId { get; set; }
        public Sunday Sunday { get; set; }
    }
}
