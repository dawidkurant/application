namespace Papu.Models.Update.TimesOfDay
{
    public class UpdateDinnerDto
    {
        //Produkty wchodzące w skład kolacji
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład kolacji
        public int[] DishId { get; set; }
    }
}
