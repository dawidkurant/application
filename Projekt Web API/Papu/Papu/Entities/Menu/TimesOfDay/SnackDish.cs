namespace Papu.Entities
{
    public class SnackDish
    {
        public int SnackId { get; set; }
        public Snack Snack { get; set; }


        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
