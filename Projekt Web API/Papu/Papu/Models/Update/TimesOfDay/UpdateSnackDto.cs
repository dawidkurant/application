namespace Papu.Models.Update.TimesOfDay
{
    public class UpdateSnackDto
    {
        //Produkty wchodzące w skład podwieczorka
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład podwieczorka
        public int[] DishId { get; set; }
    }
}
