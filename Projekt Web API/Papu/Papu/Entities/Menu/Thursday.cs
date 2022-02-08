using System.Collections.Generic;

namespace Papu.Entities
{
    public class Thursday
    {
        public int Id { get; set; }


        //Produkty przypisane do czwartku
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do czwartku
        public virtual List<Dish> Dishes { get; set; }

        public virtual Menu Menu { get; set; }

    }
}
