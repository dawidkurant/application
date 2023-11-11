using System.Collections.Generic;

namespace Papu.Models.TimesOfDay
{
    public class TimesOfDayDto
    {
        //Produkty wchodzące w skład pory dnia
        public virtual ICollection<ProductDto> Products { get; set; }

        //Potrawy wchodzące w skład pory dnia
        public virtual ICollection<DishDto> Dishes { get; set; }
    }
}
