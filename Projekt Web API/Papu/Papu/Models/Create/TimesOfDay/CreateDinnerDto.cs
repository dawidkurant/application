using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateDinnerDto
    {
        //Produkty wchodzące w skład kolacji
        //Maksymalna długość łańcucha id produktu wynosi 3
        [MaxLength(3)]
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład kolacji
        //Maksymalna długość łańcucha id potrawy wynosi 3
        [MaxLength(3)]
        public int[] DishId { get; set; }
    }
}
