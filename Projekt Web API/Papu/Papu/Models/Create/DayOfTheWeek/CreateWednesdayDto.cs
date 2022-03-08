using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateWednesdayDto
    {
        //Śniadanie wchodzące w skład środy
        //Maksymalna długość łańcucha id środowego śniadania wynosi 3
        [MaxLength(3)]
        public int BreakfastWednesdayId { get; set; }

        //Drugie śniadanie wchodzące w skład środy
        //Maksymalna długość łańcucha id środowego drugiego śniadania wynosi 3
        [MaxLength(3)]
        public int SecondBreakfastWednesdayId { get; set; }

        //Obiad wchodzący w skład środy
        //Maksymalna długość łańcucha id środowego obiadu wynosi 3
        [MaxLength(3)]
        public int LunchWednesdayId { get; set; }

        //Podwieczorek wchodzący w skład środy
        //Maksymalna długość łańcucha id środowego podwieczorka wynosi 3
        [MaxLength(3)]
        public int SnackWednesdayId { get; set; }

        //Kolacja wchodząca w skład środy
        //Maksymalna długość łańcucha id środowej kolacji wynosi 3
        [MaxLength(3)]
        public int DinnerWednesdayId { get; set; }
    }
}
