using Papu.Entities;

namespace Papu.Models
{
    public class CreateMenuDto
    {
        //Informacje które klient może podać aby stworzyć nowy jadłospis

        //Nazwa
        public string MenuName { get; set; }

        //Opis
        public string MenuDescription { get; set; }

        //Poniedziałek wchodzący w skład jadłospisu
        public int MondayId { get; set; }

        //Wtorek wchodzący w skład jadłospisu
        public int TuesdayId { get; set; }

        //Środa wchodząca w skład jadłospisu
        public int WednesdayId { get; set; }

        //Czwartek wchodzący w skład jadłospisu
        public int ThursdayId { get; set; }

        //Piątek wchodzący w skład jadłospisu
        public int FridayId { get; set; }

        //Sobota wchodząca w skład jadłospisu
        public int SaturdayId { get; set; }

        //Niedziela wchodząca w skład jadłospisu
        public int SundayId { get; set; }
    }
}
