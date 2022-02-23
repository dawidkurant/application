using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Friday
    {
        public int FridayId { get; set; }

        public Menu Menu { get; set; }
        public int? MenuRef { get; set; }

        //Produkty przypisane do piątku
        public virtual ICollection<ProductFriday> FridayProducts { get; set; }

        //Dania przypisane do piątku
        public virtual ICollection<DishFriday> FridayDishes { get; set; }

    }
}
