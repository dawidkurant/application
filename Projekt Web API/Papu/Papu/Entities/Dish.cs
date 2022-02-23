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


        //Produkty zawierające się w daniu
        public virtual ICollection<ProductDish> DishProducts { get; set; }

        //Dania przypisane do poniedziałku
        public virtual ICollection<DishMonday> MondayDishes { get; set; }

        //Dania przypisane do wtorku
        public virtual ICollection<DishTuesday> TuesdayDishes { get; set; }

        //Dania przypisane do środy
        public virtual ICollection<DishWednesday> WednesdayDishes { get; set; }

        //Dania przypisane do czwartku
        public virtual ICollection<DishThursday> ThursdayDishes { get; set; }

        //Dania przypisane do piątku
        public virtual ICollection<DishFriday> FridayDishes { get; set; }

        //Dania przypisane do soboty
        public virtual ICollection<DishSaturday> SaturdayDishes { get; set; }

        //Dania przypisane do niedzieli
        public virtual ICollection<DishSunday> SundayDishes { get; set; }

    }
}
