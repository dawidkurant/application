using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Tuesday
    {
        public int TuesdayId { get; set; }

        public Menu Menu { get; set; }
        public int? MenuRef { get; set; }

        //Produkty przypisane do wtorku
        public virtual ICollection<ProductTuesday> TuesdayProducts { get; set; }

        //Dania przypisane do wtorku
        public virtual ICollection<DishTuesday> TuesdayDishes { get; set; }
    }
}
