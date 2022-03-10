using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateSnackDto
    {
        //Produkty wchodzące w skład podwieczorka
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład podwieczorka
        public int[] DishId { get; set; }
    }
}
