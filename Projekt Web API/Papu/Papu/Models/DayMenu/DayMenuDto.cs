using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class DayMenuDto
    {
        // Identyfikator dnia
        public int DayMenuId { get; set; }

        // Dzień
        public DayOfWeek DayOfWeek { get; set; }

        // Pory dnia zawierające się w dniu
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
