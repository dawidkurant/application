using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Friday
    {
        public int FridayId { get; set; }


        //Produkty przypisane do piątku
        public virtual List<Product> FridayProducts { get; set; }

        //Dania przypisane do piątku
        public virtual List<Dish> FridayDishes { get; set; }

    }
}
