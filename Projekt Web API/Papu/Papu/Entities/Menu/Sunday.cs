using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Sunday
    {
        public int SundayId { get; set; }


        //Produkty przypisane do niedzieli
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do niedzieli
        public virtual List<Dish> Dishes { get; set; }
    }
}
