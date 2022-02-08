using System.Collections.Generic;

namespace Papu.Entities
{
    public class Sunday
    {
        public int Id { get; set; }


        //Produkty przypisane do niedzieli
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do niedzieli
        public virtual List<Dish> Dishes { get; set; }

        public virtual Menu Menu { get; set; }

    }
}
