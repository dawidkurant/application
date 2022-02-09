using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Friday
    {
        public int FridayId { get; set; }


        //Produkty przypisane do piątku
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do piątku
        public virtual List<Dish> Dishes { get; set; }

    }
}
