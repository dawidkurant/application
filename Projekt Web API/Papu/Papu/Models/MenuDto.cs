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
        public virtual ICollection<ProductDto> MondayProducts { get; set; }

        //Dania przypisane do poniedziałku
        public virtual ICollection<DishDto> MondayDishes { get; set; }

        //Produkty przypisane do wtorku
        public virtual ICollection<ProductDto> TuesdayProducts { get; set; }

        //Dania przypisane do wtorku
        public virtual ICollection<DishDto> TuesdayDishes { get; set; }

        //Produkty przypisane do środy
        public virtual ICollection<ProductDto> WednesdayProducts { get; set; }

        //Dania przypisane do środy
        public virtual ICollection<DishDto> WednesdayDishes { get; set; }

        //Produkty przypisane do czwartku
        public virtual ICollection<ProductDto> ThursdayProducts { get; set; }

        //Dania przypisane do czwartku
        public virtual ICollection<DishDto> ThursdayDishes { get; set; }

        //Produkty przypisane do piątku
        public virtual ICollection<ProductDto> FridayProducts { get; set; }

        //Dania przypisane do piątku
        public virtual ICollection<DishDto> FridayDishes { get; set; }

        //Produkty przypisane do soboty
        public virtual ICollection<ProductDto> SaturdayProducts { get; set; }

        //Dania przypisane do soboty
        public virtual ICollection<DishDto> SaturdayDishes { get; set; }

        //Produkty przypisane do niedzieli
        public virtual ICollection<ProductDto> SundayProducts { get; set; }

        //Dania przypisane do niedzieli
        public virtual ICollection<DishDto> SundayDishes { get; set; }
    }
}
