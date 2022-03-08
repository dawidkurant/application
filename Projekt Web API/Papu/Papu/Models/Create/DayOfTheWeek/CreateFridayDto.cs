using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateFridayDto
    {
        //Śniadanie wchodzące w skład piątku
        //Maksymalna długość łańcucha id piątkowego śniadania wynosi 3
        [MaxLength(3)]
        public int BreakfastFridayId { get; set; }

        //Drugie śniadanie wchodzące w skład piątku
        //Maksymalna długość łańcucha id piątkowego drugiego śniadania wynosi 3
        [MaxLength(3)]
        public int SecondBreakfastFridayId { get; set; }

        //Obiad wchodzący w skład piątku
        //Maksymalna długość łańcucha id piątkowego obiadu wynosi 3
        [MaxLength(3)]
        public int LunchFridayId { get; set; }

        //Podwieczorek wchodzący w skład piątku
        //Maksymalna długość łańcucha id piątkowego podwieczorka wynosi 3
        [MaxLength(3)]
        public int SnackFridayId { get; set; }

        //Kolacja wchodząca w skład piątku
        //Maksymalna długość łańcucha id piątkowej kolacji wynosi 3
        [MaxLength(3)]
        public int DinnerFridayId { get; set; }
    }
}
