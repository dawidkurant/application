namespace Papu.Models.Update.DayOfTheWeek
{
    public class UpdateSundayDto
    {
        //Śniadanie wchodzące w skład niedzieli
        public int BreakfastSundayId { get; set; }

        //Drugie śniadanie wchodzące w skład niedzieli
        public int SecondBreakfastSundayId { get; set; }

        //Obiad wchodzący w skład niedzieli
        public int LunchSundayId { get; set; }

        //Podwieczorek wchodzący w skład niedzieli
        public int SnackSundayId { get; set; }

        //Kolacja wchodząca w skład niedzieli
        public int DinnerSundayId { get; set; }
    }
}
