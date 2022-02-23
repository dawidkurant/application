namespace Papu.Entities
{
    public class DishMonday
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int MondayId { get; set; }
        public Monday Monday { get; set; }
    }
}
