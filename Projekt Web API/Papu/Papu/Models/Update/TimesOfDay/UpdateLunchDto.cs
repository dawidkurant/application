namespace Papu.Models.Update.TimesOfDay
{
    public class UpdateLunchDto
    {
        //Produkty wchodzące w skład obiadu
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład obiadu
        public int[] DishId { get; set; }
    }
}
