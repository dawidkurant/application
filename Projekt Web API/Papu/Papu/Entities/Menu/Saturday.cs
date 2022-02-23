using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Saturday
    {
        public int SaturdayId { get; set; }

        public Menu Menu { get; set; }
        public int? MenuRef { get; set; }

        //Produkty przypisane do soboty
        public virtual ICollection<ProductSaturday> SaturdayProducts { get; set; }

        //Dania przypisane do soboty
        public virtual ICollection<DishSaturday> SaturdayDishes { get; set; }
    }
}
