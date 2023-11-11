namespace Papu.Models.Update.DayOfTheWeek
{
    public class UpdateDayOfTheWeekDto
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
