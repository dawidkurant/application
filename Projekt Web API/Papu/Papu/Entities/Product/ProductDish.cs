using Newtonsoft.Json;

namespace Papu.Entities
{
    public class ProductDish
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }
    }
}
