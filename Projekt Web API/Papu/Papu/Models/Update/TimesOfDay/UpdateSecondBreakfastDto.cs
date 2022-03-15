namespace Papu.Models.Update.TimesOfDay
{
    public class UpdateSecondBreakfastDto
    {
        //Produkty wchodzące w skład drugiego śniadania
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład drugiego śniadania
        public int[] DishId { get; set; }
    }
}
