using System.Collections.Generic;

namespace Papu.Entities
{
    public class Friday
    {
        public int Id { get; set; }


        //Produkty przypisane do piątku
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do piątku
        public virtual List<Dish> Dishes { get; set; }


    }
}
