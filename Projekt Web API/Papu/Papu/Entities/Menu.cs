namespace Papu.Entities
{
    public class Menu
    {
        //Podstawowe informacje dotyczące jadłospisu

        //Id
        public int MenuId { get; set; }

        //Nazwa
        public string MenuName { get; set; }

        //Opis
        public string MenuDescription { get; set; }

        //Poniedziałek
        public int MondayId { get; set; }
        public virtual Monday Monday { get; set; }

        //Wtorek
        public int TuesdayId { get; set; }
        public virtual Tuesday Tuesday { get; set; }

        //Środa
        public int WednesdayId { get; set; }
        public virtual Wednesday Wednesday { get; set; }

        //Czwartek
        public int ThursdayId { get; set; }
        public virtual Thursday Thursday { get; set; }

        //Piątek
        public int FridayId { get; set; }
        public virtual Friday Friday { get; set; }

        //Sobota
        public int SaturdayId { get; set; }
        public virtual Saturday Saturday { get; set; }

        //Niedziela
        public int SundayId { get; set; }
        public virtual Sunday Sunday { get; set; }
    }
}
