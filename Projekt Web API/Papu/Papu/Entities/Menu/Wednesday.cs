using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Wednesday
    {
        public int WednesdayId { get; set; }


        //Produkty przypisane do środy
        public virtual List<Product> WednesdayProducts { get; set; }

        //Dania przypisane do środy
        public virtual List<Dish> WednesdayDishes { get; set; }
    }
}
