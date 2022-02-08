using System.Collections.Generic;

namespace Papu.Entities
{
    public class Saturday
    {
        public int Id { get; set; }


        //Produkty przypisane do soboty
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do soboty
        public virtual List<Dish> Dishes { get; set; }

        public virtual Menu Menu { get; set; }

    }
}
