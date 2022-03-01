namespace Papu.Models.Create
{
    public class CreateMondayDto
    {
        //Id poniedziałku
        public int MondayId { get; set; }

        //Śniadanie wchodzące w skład poniedziałku
        public int BreakfastId { get; set; }

        //Drugie śniadanie wchodzące w skład poniedziałku
        public int SecondBreakfastId { get; set; }

        //Obiad wchodzący w skład poniedziałku
        public int LunchId { get; set; }

        //Podwieczorek wchodzący w skład poniedziałku
        public int SnackId { get; set; }

        //Kolacja wchodząca w skład poniedziałku
        public int DinnerId { get; set; }

    }
}
