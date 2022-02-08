using System.Collections.Generic;

namespace Papu.Entities
{
    public class Tuesday
    {
        public int Id { get; set; }


        //Produkty przypisane do wtorku
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do wtorku
        public virtual List<Dish> Dishes { get; set; }

        public virtual Menu Menu { get; set; }

    }
}
