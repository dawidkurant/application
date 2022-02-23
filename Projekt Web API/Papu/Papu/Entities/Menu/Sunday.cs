using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Sunday
    {
        public int SundayId { get; set; }

        public Menu Menu { get; set; }
        public int? MenuRef { get; set; }

        //Produkty przypisane do niedzieli
        public virtual ICollection<ProductSunday> SundayProducts { get; set; }

        //Dania przypisane do niedzieli
        public virtual ICollection<DishSunday> SundayDishes { get; set; }
    }
}
