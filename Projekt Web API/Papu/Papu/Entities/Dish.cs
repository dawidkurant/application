using System.Collections.Generic;

namespace Papu.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MethodOfPeparation { get; set; }
        public int Portions { get; set; }
        public int PreparationTime { get; set; }
        public string Size { get; set; }
        public bool Status { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
