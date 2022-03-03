using System.Collections.Generic;

namespace Papu.Models
{
    public class WednesdayDto
    {
        //Podstawowe informacje dotyczące środy dostępne dla klienta

        //Id wtorku
        public int WednesdayId { get; set; }

        //Śniadanie wchodzące w skład środy
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastWednesdayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> BreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> BreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład środy
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastWednesdayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> SecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> SecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład środy
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchWednesdayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> LunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> LunchDishes { get; set; }

        //Podwieczorek wchodzący w skład środy
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackWednesdayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> SnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> SnackDishes { get; set; }

        ///Kolacja wchodząca w skład środy
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerWednesdayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> DinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> DinnerDishes { get; set; }
    }
}
