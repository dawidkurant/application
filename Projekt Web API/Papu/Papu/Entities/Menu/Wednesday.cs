using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Wednesday
    {
        public int WednesdayId { get; set; }

        public Menu Menu { get; set; }
        public int? MenuRef { get; set; }

        //Produkty przypisane do środy
        public virtual ICollection<ProductWednesday> WednesdayProducts { get; set; }

        //Dania przypisane do środy
        public virtual ICollection<DishWednesday> WednesdayDishes { get; set; }
    }
}
