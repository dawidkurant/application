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
        //Maksymalna długość łańcucha nazwy jadłospisu wynosi 50
        [MaxLength(50)]
        public string MenuName { get; set; }

        //Opis
        //Maksymalna długość łańcucha opisu jadłospisu wynosi 500
        [MaxLength(500)]
        public string MenuDescription { get; set; }

        //Poniedziałek wchodzący w skład jadłospisu
        [MaxLength(3)]
        public int MondayId { get; set; }

        //Wtorek wchodzący w skład jadłospisu
        [MaxLength(3)]
        public int TuesdayId { get; set; }

        //Środa wchodząca w skład jadłospisu
        [MaxLength(3)]
        public int WednesdayId { get; set; }

        //Czwartek wchodzący w skład jadłospisu
        [MaxLength(3)]
        public int ThursdayId { get; set; }

        //Piątek wchodzący w skład jadłospisu
        [MaxLength(3)]
        public int FridayId { get; set; }

        //Sobota wchodząca w skład jadłospisu
        [MaxLength(3)]
        public int SaturdayId { get; set; }

        //Niedziela wchodząca w skład jadłospisu
        [MaxLength(3)]
        public int SundayId { get; set; }
    }
}
