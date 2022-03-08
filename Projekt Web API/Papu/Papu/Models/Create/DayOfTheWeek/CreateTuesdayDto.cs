using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateTuesdayDto
    {
        //Śniadanie wchodzące w skład wtorku
        //Maksymalna długość łańcucha id wtorkowego śniadania wynosi 3
        [MaxLength(3)]
        public int BreakfastTuesdayId { get; set; }

        //Drugie śniadanie wchodzące w skład wtorku
        //Maksymalna długość łańcucha id wtorkowego drugiego śniadania wynosi 3
        [MaxLength(3)]
        public int SecondBreakfastTuesdayId { get; set; }

        //Obiad wchodzący w skład wtorku
        //Maksymalna długość łańcucha id wtorkowego obiadu wynosi 3
        [MaxLength(3)]
        public int LunchTuesdayId { get; set; }

        //Podwieczorek wchodzący w skład wtorku
        //Maksymalna długość łańcucha id wtorkowego podwieczorka wynosi 3
        [MaxLength(3)]
        public int SnackTuesdayId { get; set; }

        //Kolacja wchodząca w skład wtorku
        //Maksymalna długość łańcucha id wtorkowej kolacji wynosi 3
        [MaxLength(3)]
        public int DinnerTuesdayId { get; set; }
    }
}
