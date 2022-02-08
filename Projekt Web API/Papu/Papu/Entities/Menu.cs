namespace Papu.Entities
{
    public class Menu
    {
        //Podstawowe informacje dotyczące jadłospisu

        //Id
        public int Id { get; set; }

        //Nazwa
        public string Name { get; set; }

        //Opis
        public string Description { get; set; }

        //Id poniedziałku
        public int MondayId { get; set; }

        //Poniedziałek
        public virtual Monday Monday { get; set; }

        //Id wtorku
        public int TuesdayId { get; set; }

        //Wtorek
        public virtual Tuesday Tuesday { get; set; }

        //Id środy
        public int WednesdayId { get; set; }

        //Środa
        public virtual Wednesday Wednesday { get; set; }

        //Id czwartku
        public int ThursdayId { get; set; }

        //Czwartek
        public virtual Thursday Thursday { get; set; }

        //Id piątku
        public int FridayId { get; set; }

        //Piątek
        public virtual Friday Friday { get; set; }

        //Id soboty
        public int SaturdayId { get; set; }

        //Sobota
        public virtual Saturday Saturday { get; set; }

        //Id niedzieli
        public int SundayId { get; set; }

        //Niedziela
        public virtual Sunday Sunday { get; set; }
    }
}
