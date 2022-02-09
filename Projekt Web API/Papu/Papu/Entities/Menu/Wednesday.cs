using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Wednesday
    {
        public int WednesdayId { get; set; }


        //Produkty przypisane do środy
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do środy
        public virtual List<Dish> Dishes { get; set; }
    }
}
