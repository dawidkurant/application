using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Monday
    {
        public int MondayId { get; set; }


        //Produkty przypisane do poniedziałku
        public virtual List<Product> Products { get; set; }

        //Dania przypisane do poniedziałku
        public virtual List<Dish> Dishes { get; set; }
    }
}
