namespace Papu.Models
{
    public class CreateDinnerDto
    {
        //Produkty wchodzące w skład kolacji
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład kolacji
        public int[] DishId { get; set; }
    }
}
