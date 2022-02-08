using System.Collections.Generic;

namespace Papu.Entities
{
    public class Monday
    {
        public int Id { get; set; }


        //Produkty przypisane do poniedziałku
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do poniedziałku
        public virtual List<Dish> Dishes { get; set; }

        public virtual Menu Menu { get; set; }

    }
}
