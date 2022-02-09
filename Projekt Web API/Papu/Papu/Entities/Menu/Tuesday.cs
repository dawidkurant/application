using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Tuesday
    {
        public int TuesdayId { get; set; }


        //Produkty przypisane do wtorku
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do wtorku
        public virtual List<Dish> Dishes { get; set; }
    }
}
