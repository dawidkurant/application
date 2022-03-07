using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateThursdayDto
    {
        //Śniadanie wchodzące w skład czwartku
        //Maksymalna długość łańucha id czwartkowego śniadania wynosi 3
        [MaxLength(3)]
        public int BreakfastThursdayId { get; set; }

        //Drugie śniadanie wchodzące w skład czwartku
        //Maksymalna długość łańucha id czwartkowego drugiego śniadania wynosi 3
        [MaxLength(3)]
        public int SecondBreakfastThursdayId { get; set; }

        //Obiad wchodzący w skład czwartku
        //Maksymalna długość łańucha id czwartkowego obiadu wynosi 3
        [MaxLength(3)]
        public int LunchThursdayId { get; set; }

        //Podwieczorek wchodzący w skład czwartku
        //Maksymalna długość łańucha id czwartkowego podwieczorku wynosi 3
        [MaxLength(3)]
        public int SnackThursdayId { get; set; }

        //Kolacja wchodząca w skład czwartku
        //Maksymalna długość łańucha id czwartkowej kolacji wynosi 3
        [MaxLength(3)]
        public int DinnerThursdayId { get; set; }
    }
}
