using Papu.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Papu.Models
{
    public class DishDto
    {
        //Podstawowe informacje dotyczące potrawy dostępne dla klienta

        //Id
        public int DishId { get; set; }

        //Nazwa
        public string Name { get; set; }

        //Opis
        public string Description { get; set; }

        //Sposób przygotowania
        public string MethodOfPeparation { get; set; }

        //Produkty potrawy składającej się z ilu porcji
        public int Portions { get; set; }

        //Czas przygotowania w minutach
        public int PreparationTime { get; set; }

        //Rodzaj
        public virtual List<KindOf> KindsOf { get; set; }

        //Rozmiar
        public int Size { get; set; }

        //Typ
        public virtual List<Type> Types { get; set; }

        //Produkty zawierające się w daniu
        [JsonIgnore]
        public virtual List<ProductDto> Products { get; set; }
    }
}
