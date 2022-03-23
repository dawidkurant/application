using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Papu.Entities
{
    public class Dish
    {
        //Podstawowe informacje dotyczące potrawy

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
        public virtual ICollection<DishKindOf> DishKindsOf { get; set; }

        //Rozmiar
        public int Size { get; set; }

        //Typ
        public virtual ICollection<DishType> DishTypes { get; set; }

        //Zdjęcie
        public string DishImagePath { get; set; }

        //Twórca danej potrawy
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danej potrawy
        public virtual User CreatedBy { get; set; }

        //Produkty zawierające się w daniu
        public virtual ICollection<ProductDish> DishProducts { get; set; }

        //Dania zawierające się w śniadaniu
        public virtual ICollection<BreakfastDish> BreakfastDishes { get; set; }

        //Dania zawierające się w drugim śniadaniu
        public virtual ICollection<SecondBreakfastDish> SecondBreakfastDishes { get; set; }

        //Dania zawierające się w obiedzie
        public virtual ICollection<LunchDish> LunchDishes { get; set; }

        //Dania zawierające się w podwieczorku
        public virtual ICollection<SnackDish> SnackDishes { get; set; }

        //Dania zawierające się w kolacji
        public virtual ICollection<DinnerDish> DinnerDishes { get; set; }

    }
}
