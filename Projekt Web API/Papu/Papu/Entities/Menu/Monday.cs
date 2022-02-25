using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Monday
    {
        public int MondayId { get; set; }

        public Menu Menu { get; set; }

        public int? MenuRef { get; set; }

        //Produkty przypisane do poniedziałku
        public virtual ICollection<ProductMonday> MondayProducts { get; set; }

        //Dania przypisane do poniedziałku
        public virtual ICollection<DishMonday> MondayDishes { get; set; }
    }
}
