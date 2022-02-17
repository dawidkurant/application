namespace Papu.Entities
{
    public class Menu
    {
        //Podstawowe informacje dotyczące jadłospisu

        //Id
        public int MenuId { get; set; }

        //Nazwa
        public string Name { get; set; }

        //Opis
        public string Description { get; set; }

        //Poniedziałek
        public virtual Monday Monday { get; set; }

        //Wtorek
        public virtual Tuesday Tuesday { get; set; }

        //Środa
        public virtual Wednesday Wednesday { get; set; }

        //Czwartek
        public virtual Thursday Thursday { get; set; }

        //Piątek
        public virtual Friday Friday { get; set; }

        //Sobota
        public virtual Saturday Saturday { get; set; }

        //Niedziela
        public virtual Sunday Sunday { get; set; }
    }
}
