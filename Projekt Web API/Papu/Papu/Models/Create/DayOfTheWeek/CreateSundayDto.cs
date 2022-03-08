using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateSundayDto
    {
        //Śniadanie wchodzące w skład niedzieli
        //Maksymalna długość łańcucha id niedzielnego śniadania wynosi 3
        [MaxLength(3)]
        public int BreakfastSundayId { get; set; }

        //Drugie śniadanie wchodzące w skład niedzieli
        //Maksymalna długość łańcucha id niedzielnego drugiego śniadania wynosi 3
        [MaxLength(3)]
        public int SecondBreakfastSundayId { get; set; }

        //Obiad wchodzący w skład niedzieli
        //Maksymalna długość łańcucha id niedzielnego obiadu wynosi 3
        [MaxLength(3)]
        public int LunchSundayId { get; set; }

        //Podwieczorek wchodzący w skład niedzieli
        //Maksymalna długość łańcucha id niedzielnego podwieczorka wynosi 3
        [MaxLength(3)]
        public int SnackSundayId { get; set; }

        //Kolacja wchodząca w skład niedzieli
        //Maksymalna długość łańcucha id niedzielnej kolacji wynosi 3
        [MaxLength(3)]
        public int DinnerSundayId { get; set; }
    }
}
