namespace Papu.Models
{
    public class CreateFridayDto
    {
        //Śniadanie wchodzące w skład piątku
        public int BreakfastFridayId { get; set; }

        //Drugie śniadanie wchodzące w skład piątku
        public int SecondBreakfastFridayId { get; set; }

        //Obiad wchodzący w skład piątku
        public int LunchFridayId { get; set; }

        //Podwieczorek wchodzący w skład piątku
        public int SnackFridayId { get; set; }

        //Kolacja wchodząca w skład piątku
        public int DinnerFridayId { get; set; }
    }
}
