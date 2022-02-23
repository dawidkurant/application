using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Thursday
    {
        public int ThursdayId { get; set; }

        public Menu Menu { get; set; }
        public int? MenuRef { get; set; }

        //Produkty przypisane do czwartku
        public virtual ICollection<ProductThursday> ThursdayProducts { get; set; }

        //Dania przypisane do czwartku
        public virtual ICollection<DishThursday> ThursdayDishes { get; set; }
    }
}
