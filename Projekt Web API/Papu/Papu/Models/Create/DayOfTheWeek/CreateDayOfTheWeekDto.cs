namespace Papu.Models.Create.DayOfTheWeek
{
    public class CreateDayOfTheWeekDto
    {
        //Śniadanie wchodzące w skład dnia
        public int BreakfastId { get; set; }

        //Drugie śniadanie wchodzące w skład dnia
        public int SecondBreakfastId { get; set; }

        //Obiad wchodzący w skład dnia
        public int LunchId { get; set; }

        //Podwieczorek wchodzący w skład dnia
        public int SnackId { get; set; }

        //Kolacja wchodząca w skład dnia
        public int DinnerId { get; set; }
    }
}
