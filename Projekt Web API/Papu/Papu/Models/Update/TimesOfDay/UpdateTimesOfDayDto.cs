namespace Papu.Models.Update.TimesOfDay
{
    public class UpdateTimesOfDayDto
    {
        //Produkty wchodzące w skład pory dnia
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład pory dnia
        public int[] DishId { get; set; }
    }
}
