using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class MenuDto
    {
        //Podstawowe informacje dotyczące jadłospisu

        //Id
        public int MenuId { get; set; }

        //Nazwa
        public string MenuName { get; set; }

        //Opis
        public string MenuDescription { get; set; }

        //Produkty przypisane do poniedziałku
        public virtual List<ProductDto> MondayProducts { get; set; }

        //Dania przypisane do poniedziałku
        public virtual List<DishDto> MondayDishes { get; set; }

        //Produkty przypisane do wtorku
        public virtual List<ProductDto> TuesdayProducts { get; set; }

        //Dania przypisane do wtorku
        public virtual List<DishDto> TuesdayDishes { get; set; }

        //Produkty przypisane do środy
        public virtual List<ProductDto> WednesdayProducts { get; set; }

        //Dania przypisane do środy
        public virtual List<DishDto> WednesdayDishes { get; set; }

        //Produkty przypisane do czwartku
        public virtual List<ProductDto> ThursdayProducts { get; set; }

        //Dania przypisane do czwartku
        public virtual List<DishDto> ThursdayDishes { get; set; }

        //Produkty przypisane do piątku
        public virtual List<ProductDto> FridayProducts { get; set; }

        //Dania przypisane do piątku
        public virtual List<DishDto> FridayDishes { get; set; }

        //Produkty przypisane do soboty
        public virtual List<ProductDto> SaturdayProducts { get; set; }

        //Dania przypisane do soboty
        public virtual List<DishDto> SaturdayDishes { get; set; }

        //Produkty przypisane do niedzieli
        public virtual List<ProductDto> SundayProducts { get; set; }

        //Dania przypisane do niedzieli
        public virtual List<DishDto> SundayDishes { get; set; }
    }
}
