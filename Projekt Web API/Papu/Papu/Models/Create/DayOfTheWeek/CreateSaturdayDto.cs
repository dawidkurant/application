using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateSaturdayDto
    {
        //Śniadanie wchodzące w skład soboty
        //Maksymalna długość łańcucha id sobotniego śniadania wynosi 3
        [MaxLength(3)]
        public int BreakfastSaturdayId { get; set; }

        //Drugie śniadanie wchodzące w skład soboty
        //Maksymalna długość łańcucha id sobotniego drugiego śniadania wynosi 3
        [MaxLength(3)]
        public int SecondBreakfastSaturdayId { get; set; }

        //Obiad wchodzący w skład soboty
        //Maksymalna długość łańcucha id sobotniego obiadu wynosi 3
        [MaxLength(3)]
        public int LunchSaturdayId { get; set; }

        //Podwieczorek wchodzący w skład soboty
        //Maksymalna długość łańcucha id sobotniego podwieczorka wynosi 3
        [MaxLength(3)]
        public int SnackSaturdayId { get; set; }

        //Kolacja wchodząca w skład soboty
        //Maksymalna długość łańcucha id sobotniej kolacji wynosi 3
        [MaxLength(3)]
        public int DinnerSaturdayId { get; set; }
    }
}
