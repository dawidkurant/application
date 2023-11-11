namespace Papu.Entities
{
    public class TimesOfDay
    {
        //Twórca danego posiłku z konkretnej pory
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danego posiłku z konkretnej pory
        public virtual User CreatedBy { get; set; }
        public virtual Monday Monday { get; set; }
        public virtual Tuesday Tuesday { get; set; }
        public virtual Wednesday Wednesday { get; set; }
        public virtual Thursday Thursday { get; set; }
        public virtual Friday Friday { get; set; }
        public virtual Saturday Saturday { get; set; }
        public virtual Sunday Sunday { get; set; }
    }
}
