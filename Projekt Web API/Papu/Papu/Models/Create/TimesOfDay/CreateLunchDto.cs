using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateLunchDto
    {
        //Produkty wchodzące w skład obiadu
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład obiadu
        public int[] DishId { get; set; }
    }
}
