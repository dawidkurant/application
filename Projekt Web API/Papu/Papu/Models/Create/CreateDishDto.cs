using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class CreateDishDto
    {
        //Informacje, które może podać klient, aby stworzyć potrawę

        //Nazwa
        public string DishName { get; set; }

        //Opis
        public string DishDescription { get; set; }

        //Sposób przygotowania
        public string MethodOfPeparation { get; set; }

        //Produkty potrawy składającej się z ilu porcji
        public int Portions { get; set; }

        //Czas przygotowania w minutach
        public int PreparationTime { get; set; }

        //Rodzaj
        public int[] KindOfId { get; set; }

        //Rozmiar
        public int Size { get; set; }

        //Typ
        public int[] TypeId { get; set; }

        //Zdjęcie
        public string DishImagePath { get; set; }

        //Produkty zawierające się w daniu
        public int[] ProductId { get; set; }
    }
}
