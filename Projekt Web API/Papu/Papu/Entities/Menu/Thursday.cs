using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Thursday
    {
        public int ThursdayId { get; set; }


        //Produkty przypisane do czwartku
        public virtual List<Product> ThursdayProducts { get; set; }

        //Dania przypisane do czwartku
        public virtual List<Dish> ThursdayDishes { get; set; }
    }
}
