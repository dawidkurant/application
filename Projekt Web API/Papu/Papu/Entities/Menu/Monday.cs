using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Monday
    {
        public int MondayId { get; set; }
        public int BreakfastMonday { get; set; }
        public Breakfast Breakfast { get; set; }
        public int SecondBreakfastMonday { get; set; }
        public SecondBreakfast SecondBreakfast { get; set; }
        public int LunchMonday { get; set; }
        public Lunch Lunch { get; set; }
        public int SnackMonday { get; set; }
        public Snack Snack { get; set; }
        public int DinnerMonday { get; set; }
        public Dinner Dinner { get; set; }

    }
}
