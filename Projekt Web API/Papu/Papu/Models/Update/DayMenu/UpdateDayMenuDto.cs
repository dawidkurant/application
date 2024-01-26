using Papu.Entities;

namespace Papu.Models
{
    public class UpdateDayMenuDto
    {
        // Dzień
        public DayOfWeek DayOfWeek { get; set; }

        // Pory dnia zawierające się w dniu
        public int[] MealId { get; set; }
    }
}
