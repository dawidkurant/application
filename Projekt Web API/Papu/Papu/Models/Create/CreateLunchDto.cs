namespace Papu.Models.Create
{
    public class CreateLunchDto
    {
        //Produkty wchodzące w skład obiadu
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład obiadu
        public int[] DishId { get; set; }
    }
}
