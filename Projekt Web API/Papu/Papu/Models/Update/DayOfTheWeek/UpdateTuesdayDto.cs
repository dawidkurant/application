namespace Papu.Models.Update.DayOfTheWeek
{
    public class UpdateTuesdayDto
    {
        //Śniadanie wchodzące w skład wtorku
        public int BreakfastTuesdayId { get; set; }

        //Drugie śniadanie wchodzące w skład wtorku
        public int SecondBreakfastTuesdayId { get; set; }

        //Obiad wchodzący w skład wtorku
        public int LunchTuesdayId { get; set; }

        //Podwieczorek wchodzący w skład wtorku
        public int SnackTuesdayId { get; set; }

        //Kolacja wchodząca w skład wtorku
        public int DinnerTuesdayId { get; set; }
    }
}
