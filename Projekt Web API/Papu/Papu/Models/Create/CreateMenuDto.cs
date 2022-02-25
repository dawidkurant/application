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

        //Poniedziałek
        public int[] MondayProductsId { get; set; }
        public int[] MondayDishesId { get; set; }

        //Wtorek
        public int[] TuesdayProductsId { get; set; }
        public int[] TuesdayDishesId { get; set; }

        //Środa
        public int[] WednesdayProductsId { get; set; }
        public int[] WednesdayDishesId { get; set; }

        //Czwartek
        public int[] ThursdayProductsId { get; set; }
        public int[] ThursdayDishesId { get; set; }

        //Piątek
        public int[] FridayProductsId { get; set; }
        public int[] FridayDishesId { get; set; }

        //Sobota
        public int[] SaturdayProductsId { get; set; }
        public int[] SaturdayDishesId { get; set; }

        //Niedziela
        public int[] SundayProductsId { get; set; }
        public int[] SundayDishesId { get; set; }
    }
}
