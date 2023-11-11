namespace Papu.Entities
{
    public class DishKindOf
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }


        public int KindOfId { get; set; }
        public KindOf KindOf { get; set; }
    }
}
