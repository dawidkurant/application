using Papu.Models.TimesOfDay;

namespace Papu.Models
{
    public class LunchDto : TimesOfDayDto
    {
        //Podstawowe informacje dotyczące obiadu dostępne dla klienta

        //Id obiadu
        public int LunchId { get; set; }
    }
}
