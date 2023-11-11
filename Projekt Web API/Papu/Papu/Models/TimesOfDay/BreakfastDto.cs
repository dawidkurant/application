using Papu.Models.TimesOfDay;

namespace Papu.Models
{
    public class BreakfastDto : TimesOfDayDto
    {
        //Podstawowe informacje dotyczące śniadania dostępne dla klienta

        //Id śniadania
        public int BreakfastId { get; set; }
    }
}
