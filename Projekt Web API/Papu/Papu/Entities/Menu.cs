namespace Papu.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MondayId { get; set; }
        public virtual Monday Monday { get; set; }
        public int TuesdayId { get; set; }
        public virtual Tuesday Tuesday { get; set; }
        public int WednesdayId { get; set; }
        public virtual Wednesday Wednesday { get; set; }
        public int ThursdayId { get; set; }
        public virtual Thursday Thursday { get; set; }
        public int FridayId { get; set; }
        public virtual Friday Friday { get; set; }
        public int SaturdayId { get; set; }
        public virtual Saturday Saturday { get; set; }
        public int SundayId { get; set; }
        public virtual Sunday Sunday { get; set; }
    }
}
