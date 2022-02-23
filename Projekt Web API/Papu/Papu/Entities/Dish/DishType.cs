namespace Papu.Entities
{
    public class DishType
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
