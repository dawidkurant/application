namespace Papu.Models.Create.TimesOfDay
{
    public class CreateTimesOfDayDto
    {
        //Produkty wchodzące w skład posiłku
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład posiłku
        public int[] DishId { get; set; }
    }
}
