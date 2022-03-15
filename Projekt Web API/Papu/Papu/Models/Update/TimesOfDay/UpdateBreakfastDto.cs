namespace Papu.Models.Update.TimesOfDay
{
    public class UpdateBreakfastDto
    {
        //Produkty wchodzące w skład śniadania
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład śniadania
        public int[] DishId { get; set; }
    }
}
