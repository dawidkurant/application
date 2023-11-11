using Papu.Models.TimesOfDay;

namespace Papu.Models
{
    public class DinnerDto : TimesOfDayDto
    {
        //Podstawowe informacje dotyczące kolacji dostępne dla klienta

        //Id kolacji
        public int DinnerId { get; set; }
    }
}
