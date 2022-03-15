namespace Papu.Models.Update.DayOfTheWeek
{
    public class UpdateMondayDto
    {
        //Śniadanie wchodzące w skład poniedziałku
        public int BreakfastMondayId { get; set; }

        //Drugie śniadanie wchodzące w skład poniedziałku
        public int SecondBreakfastMondayId { get; set; }

        //Obiad wchodzący w skład poniedziałku
        public int LunchMondayId { get; set; }

        //Podwieczorek wchodzący w skład poniedziałku
        public int SnackMondayId { get; set; }

        //Kolacja wchodząca w skład poniedziałku
        public int DinnerMondayId { get; set; }
    }
}
