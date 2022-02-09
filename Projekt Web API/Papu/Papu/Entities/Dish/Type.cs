namespace Papu.Entities
{
    public class Type
    {
        //Id i Nazwa typu do którego należy danie
        public int TypeId { get; set; }
        public string Name { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
