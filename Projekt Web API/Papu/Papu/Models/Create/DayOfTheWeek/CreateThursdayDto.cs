using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateThursdayDto
    {
        //Śniadanie wchodzące w skład czwartku
        public int BreakfastThursdayId { get; set; }

        //Drugie śniadanie wchodzące w skład czwartku
        public int SecondBreakfastThursdayId { get; set; }

        //Obiad wchodzący w skład czwartku
        public int LunchThursdayId { get; set; }

        //Podwieczorek wchodzący w skład czwartku
        public int SnackThursdayId { get; set; }

        //Kolacja wchodząca w skład czwartku
        public int DinnerThursdayId { get; set; }
    }
}
