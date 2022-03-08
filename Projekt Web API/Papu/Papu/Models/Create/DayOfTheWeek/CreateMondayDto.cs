using Papu.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateMondayDto
    {
        //Śniadanie wchodzące w skład poniedziałku
        //Maksymalna długość łańcucha id poniedziałkowego śniadania wynosi 3
        [MaxLength(3)]
        public int BreakfastMondayId { get; set; }

        //Drugie śniadanie wchodzące w skład poniedziałku
        //Maksymalna długość łańcucha id poniedziałkowego drugiego śniadania wynosi 3
        [MaxLength(3)]
        public int SecondBreakfastMondayId { get; set; }

        //Obiad wchodzący w skład poniedziałku
        //Maksymalna długość łańcucha id poniedziałkowego obiadu wynosi 3
        [MaxLength(3)]
        public int LunchMondayId { get; set; }

        //Podwieczorek wchodzący w skład poniedziałku
        //Maksymalna długość łańcucha id poniedziałkowego podwieczorka wynosi 3
        [MaxLength(3)]
        public int SnackMondayId { get; set; }

        //Kolacja wchodząca w skład poniedziałku
        //Maksymalna długość łańcucha id poniedziałkowej kolacji wynosi 3
        [MaxLength(3)]
        public int DinnerMondayId { get; set; }

    }
}
