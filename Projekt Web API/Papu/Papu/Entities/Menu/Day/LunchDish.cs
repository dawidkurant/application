namespace Papu.Entities
{ 
    public class LunchDish
    {
        public int LunchId { get; set; }
        public Lunch Lunch { get; set; }


        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
