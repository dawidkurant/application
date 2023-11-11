using Papu.Models.TimesOfDay;

namespace Papu.Models
{
    public class SnackDto : TimesOfDayDto
    {
        //Podstawowe informacje dotyczące podwieczorka dostępne dla klienta

        //Id podwieczorka
        public int SnackId { get; set; }
    }
}
