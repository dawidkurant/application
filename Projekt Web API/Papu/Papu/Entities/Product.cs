using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Papu.Entities
{
    public class Product
    {

        //Podstawowe informacje dotyczące produktu

        //Id
        public int ProductId { get; set; }

        //Nazwa produktu
        public string ProductName { get; set; }

        //Kategoria
        public virtual Category Category { get; set; }

        //Grupa
        public virtual ICollection<ProductGroup> ProductGroups { get; set; }

        //Jednostka miary
        public virtual Unit Unit { get; set; }

        //Waga jednostki miary
        public decimal Weight { get; set; }

        //Żelazo
        public decimal Iron { get; set; }

        //Witamina B12
        public decimal VitaminB12 { get; set; }

        //Foliany
        public decimal Folate { get; set; }

        //Witamina D
        public decimal VitaminD { get; set; }

        //Wapń
        public decimal Calcium { get; set; }

        //Magnez
        public decimal Magnesium { get; set; }

        //Zdjęcie
        public string ProductImagePath { get; set; }

        //Twórca danego produktu
        public int? CreatedById { get; set; }

        //Zmienna reperezentująca twórcę danego produktu
        public virtual User CreatedBy { get; set; }

        //Produkty wchodzące w skład posiłku
        public virtual ICollection<ProductDish> DishProducts { get; set; }

        //Produkty zawierające się w śniadaniu
        public virtual ICollection<BreakfastProduct> BreakfastProducts { get; set; }

        //Produkty zawierające się w drugim śniadaniu
        public virtual ICollection<SecondBreakfastProduct> SecondBreakfastProducts { get; set; }

        //Produkty zawierające się w obiedzie
        public virtual ICollection<LunchProduct> LunchProducts { get; set; }

        //Produkty zawierające się w podwieczorku
        public virtual ICollection<SnackProduct> SnackProducts { get; set; }

        //Produkty zawierające się w kolacji
        public virtual ICollection<DinnerProduct> DinnerProducts { get; set; }

    }
}
