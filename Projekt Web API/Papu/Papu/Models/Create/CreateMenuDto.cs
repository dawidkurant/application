using Papu.Entities;
using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateMenuDto
    {
        //Informacje które klient może podać aby stworzyć nowy jadłospis

        //Nazwa
        //Nazwa jadłospisu jest wymagana
        [Required]
        //Maksymalna długość nazwy jadłospisu wynosi 50
        [MaxLength(50)]
        public string MenuName { get; set; }

        //Opis
        //Maksymalny opis jadłospisu wynosi 500
        [MaxLength(500)]
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
