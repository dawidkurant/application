using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class MondayDto
    {
        //Podstawowe informacje dotyczące poniedziałku dostępne dla klienta

        //Id poniedziałku
        public int MondayId { get; set; }

        //Śniadanie wchodzące w skład poniedziałku
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastMondayId { get; set; }

        //Drugie śniadanie wchodzące w skład poniedziałku
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        //public int SecondBreakfastId { get; set; }

        /*//Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> SecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> SecondBreakfastDishes { get; set; }

        //Id obiadu
        public int LunchId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> LunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> LunchDishes { get; set; }

        //Id podwieczorka
        public int SnackId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> SnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> SnackDishes { get; set; }

        //Id kolacji
        public int DinnerId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> DinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> DinnerDishes { get; set; }*/
    }
}
