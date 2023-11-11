using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class DishDto
    {
        //Podstawowe informacje dotyczące potrawy dostępne dla klienta

        //Id
        public int DishId { get; set; }

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
        public virtual ICollection<KindOf> KindsOf { get; set; }

        //Rozmiar
        public int Size { get; set; }

        //Typ
        public virtual ICollection<Type> Types { get; set; }

        //Zdjęcie
        public string DishImagePath { get; set; }


        //Produkty zawierające się w daniu
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
