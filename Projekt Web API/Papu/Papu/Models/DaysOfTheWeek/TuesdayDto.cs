using System.Collections.Generic;

namespace Papu.Models
{
    public class TuesdayDto
    {
        //Podstawowe informacje dotyczące wtorku dostępne dla klienta

        //Id wtorku
        public int TuesdayId { get; set; }

        //Śniadanie wchodzące w skład wtorku
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastTuesdayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> BreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> BreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład wtorku
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastTuesdayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> SecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> SecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład wtorku
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchTuesdayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> LunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> LunchDishes { get; set; }

        //Podwieczorek wchodzący w skład wtorku
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackTuesdayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> SnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> SnackDishes { get; set; }

        ///Kolacja wchodząca w skład wtorku
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerTuesdayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> DinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> DinnerDishes { get; set; }
    }
}
