namespace Papu.Entities
{
    public class Type
    {
        //Id i Nazwa typu do którego należy danie
        public int Id { get; set; }
        public string Name { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
