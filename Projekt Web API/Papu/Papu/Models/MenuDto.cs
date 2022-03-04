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

        //Podstawowe informacje dotyczące poniedziałku dostępne dla klienta

        //Id poniedziałku
        public int MondayId { get; set; }

        //Śniadanie wchodzące w skład poniedziałku
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastMondayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> MondayBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> MondayBreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład poniedziałku
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastMondayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> MondaySecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> MondaySecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład poniedziałku
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchMondayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> MondayLunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> MondayLunchDishes { get; set; }

        //Podwieczorek wchodzący w skład poniedziałku
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackMondayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> MondaySnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> MondaySnackDishes { get; set; }

        ///Kolacja wchodząca w skład poniedziałku
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerMondayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> MondayDinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> MondayDinnerDishes { get; set; }

        //Podstawowe informacje dotyczące wtorku dostępne dla klienta

        //Id wtorku
        public int TuesdayId { get; set; }

        //Śniadanie wchodzące w skład wtorku
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastTuesdayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> TuesdayBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> TuesdayBreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład wtorku
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastTuesdayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> TuesdaySecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> TuesdaySecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład wtorku
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchTuesdayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> TuesdayLunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> TuesdayLunchDishes { get; set; }

        //Podwieczorek wchodzący w skład wtorku
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackTuesdayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> TuesdaySnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> TuesdaySnackDishes { get; set; }

        ///Kolacja wchodząca w skład wtorku
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerTuesdayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> TuesdayDinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> TuesdayDinnerDishes { get; set; }

        //Podstawowe informacje dotyczące środy dostępne dla klienta

        //Id wtorku
        public int WednesdayId { get; set; }

        //Śniadanie wchodzące w skład środy
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastWednesdayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> WednesdayBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> WednesdayBreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład środy
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastWednesdayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> WednesdaySecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> WednesdaySecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład środy
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchWednesdayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> WednesdayLunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> WednesdayLunchDishes { get; set; }

        //Podwieczorek wchodzący w skład środy
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackWednesdayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> WednesdaySnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> WednesdaySnackDishes { get; set; }

        ///Kolacja wchodząca w skład środy
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerWednesdayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> WednesdayDinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> WednesdayDinnerDishes { get; set; }

        //Podstawowe informacje dotyczące czwartku dostępne dla klienta

        //Id soboty
        public int ThursdayId { get; set; }

        //Śniadanie wchodzące w skład czwartku
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastThursdayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> ThursdayBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> ThursdayBreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład czwartku
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastThursdayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> ThursdaySecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> ThursdaySecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład czwartku
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchThursdayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> ThursdayLunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> ThursdayLunchDishes { get; set; }

        //Podwieczorek wchodzący w skład czwartku
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackThursdayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> ThursdaySnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> ThursdaySnackDishes { get; set; }

        ///Kolacja wchodząca w skład czwartku
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerThursdayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> ThursdayDinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> ThursdayDinnerDishes { get; set; }

        //Podstawowe informacje dotyczące piątku dostępne dla klienta

        //Id piątku
        public int FridayId { get; set; }

        //Śniadanie wchodzące w skład piątku
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastFridayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> FridayBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> FridayBreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład piątku
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastFridayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> FridaySecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> FridaySecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład piątku
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchFridayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> FridayLunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> FridayLunchDishes { get; set; }

        //Podwieczorek wchodzący w skład piątku
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackFridayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> FridaySnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> FridaySnackDishes { get; set; }

        ///Kolacja wchodząca w skład piątku
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerFridayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> FridayDinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> FridayDinnerDishes { get; set; }

        //Podstawowe informacje dotyczące soboty dostępne dla klienta

        //Id soboty
        public int SaturdayId { get; set; }

        //Śniadanie wchodzące w skład soboty
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastSaturdayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> SaturdayBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> SaturdayBreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład soboty
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastSaturdayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> SaturdaySecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> SaturdaySecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład soboty
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchSaturdayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> SaturdayLunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> SaturdayLunchDishes { get; set; }

        //Podwieczorek wchodzący w skład soboty
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackSaturdayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> SaturdaySnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> SaturdaySnackDishes { get; set; }

        ///Kolacja wchodząca w skład soboty
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerSaturdayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> SaturdayDinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> SaturdayDinnerDishes { get; set; }

        //Podstawowe informacje dotyczące niedzieli dostępne dla klienta

        //Id soboty
        public int SundayId { get; set; }

        //Śniadanie wchodzące w skład niedzieli
        //Podstawowe informacje dotyczące śniadania

        //Id śniadania
        public int BreakfastSundayId { get; set; }

        //Produkty wchodzące w skład śniadania
        public virtual ICollection<ProductDto> SundayBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład śniadania
        public virtual ICollection<DishDto> SundayBreakfastDishes { get; set; }

        //Drugie śniadanie wchodzące w skład niedzieli
        //Podstawowe informacje dotyczące drugiego śniadania

        //Id drugiego śniadania
        public int SecondBreakfastSundayId { get; set; }

        //Produkty wchodzące w skład drugiego śniadania
        public virtual ICollection<ProductDto> SundaySecondBreakfastProducts { get; set; }

        //Potrawy wchodzące w skład drugiego śniadania
        public virtual ICollection<DishDto> SundaySecondBreakfastDishes { get; set; }

        //Obiad wchodzący w skład niedzieli
        //Podstawowe informacje dotyczące obiadu

        //Id obiadu
        public int LunchSundayId { get; set; }

        //Produkty wchodzące w skład obiadu
        public virtual ICollection<ProductDto> SundayLunchProducts { get; set; }

        //Potrawy wchodzące w skład obiadu
        public virtual ICollection<DishDto> SundayLunchDishes { get; set; }

        //Podwieczorek wchodzący w skład niedzieli
        //Podstawowe informacje dotyczące podwieczorka

        //Id podwieczorka
        public int SnackSundayId { get; set; }

        //Produkty wchodzące w skład podwieczorka
        public virtual ICollection<ProductDto> SundaySnackProducts { get; set; }

        //Potrawy wchodzące w skład podwieczorka
        public virtual ICollection<DishDto> SundaySnackDishes { get; set; }

        ///Kolacja wchodząca w skład niedzieli
        //Podstawowe informacje dotyczące kolacji

        //Id kolacji
        public int DinnerSundayId { get; set; }

        //Produkty wchodzące w skład kolacji
        public virtual ICollection<ProductDto> SundayDinnerProducts { get; set; }

        //Potrawy wchodzące w skład kolacji
        public virtual ICollection<DishDto> SundayDinnerDishes { get; set; }
    }
}
