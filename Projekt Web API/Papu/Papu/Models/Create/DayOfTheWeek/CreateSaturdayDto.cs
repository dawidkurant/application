namespace Papu.Models
{
    public class CreateSaturdayDto
    {
        //Śniadanie wchodzące w skład soboty
        public int BreakfastSaturdayId { get; set; }

        //Drugie śniadanie wchodzące w skład soboty
        public int SecondBreakfastSaturdayId { get; set; }

        //Obiad wchodzący w skład soboty
        public int LunchSaturdayId { get; set; }

        //Podwieczorek wchodzący w skład soboty
        public int SnackSaturdayId { get; set; }

        //Kolacja wchodząca w skład soboty
        public int DinnerSaturdayId { get; set; }
    }
}
