namespace Papu.Entities
{
    public class KindOf
    {
        //Id i Nazwa rodzaju do którego należy danie
        public int KindOfId { get; set; }
        public string Name { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
