using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Tuesday
    {
        public int TuesdayId { get; set; }


        //Produkty przypisane do wtorku
        public virtual List<Product> TuesdayProducts { get; set; }

        //Dania przypisane do wtorku
        public virtual List<Dish> TuesdayDishes { get; set; }
    }
}
