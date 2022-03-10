using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateWednesdayDto
    {
        //Śniadanie wchodzące w skład środy
        public int BreakfastWednesdayId { get; set; }

        //Drugie śniadanie wchodzące w skład środy
        public int SecondBreakfastWednesdayId { get; set; }

        //Obiad wchodzący w skład środy
        public int LunchWednesdayId { get; set; }

        //Podwieczorek wchodzący w skład środy
        public int SnackWednesdayId { get; set; }

        //Kolacja wchodząca w skład środy
        public int DinnerWednesdayId { get; set; }
    }
}
