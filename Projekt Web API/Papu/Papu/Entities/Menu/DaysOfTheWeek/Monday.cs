using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Monday
    {
        public int MondayId { get; set; }
        public int BreakfastId { get; set; }
        public virtual Breakfast Breakfast { get; set; }
        public int SecondBreakfastId { get; set; }
        public virtual SecondBreakfast SecondBreakfast { get; set; }
        public int LunchId { get; set; }
        public virtual Lunch Lunch { get; set; }
        public int SnackId { get; set; }
        public virtual Snack Snack { get; set; }
        public int DinnerId { get; set; }
        public virtual Dinner Dinner { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
