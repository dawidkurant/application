using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateLunchDto
    {
        //Produkty wchodzące w skład obiadu
        //Maksymalna długość łańcucha id produktu wynosi 3
        [MaxLength(3)]
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład obiadu
        //Maksymalna długość łańcucha id potrawy wynosi 3
        [MaxLength(3)]
        public int[] DishId { get; set; }
    }
}
