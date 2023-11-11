namespace Papu.Entities
{
    public class DayOfTheWeek
    {
        public int? BreakfastId { get; set; }
        public virtual Breakfast Breakfast { get; set; }
        public int? SecondBreakfastId { get; set; }
        public virtual SecondBreakfast SecondBreakfast { get; set; }
        public int? LunchId { get; set; }
        public virtual Lunch Lunch { get; set; }
        public int? SnackId { get; set; }
        public virtual Snack Snack { get; set; }
        public int? DinnerId { get; set; }
        public virtual Dinner Dinner { get; set; }
        public virtual Menu Menu { get; set; }

        //Twórca danego dnia
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danego dnia
        public virtual User CreatedBy { get; set; }
    }
}
