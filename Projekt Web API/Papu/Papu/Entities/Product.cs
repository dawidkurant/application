using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Product
    {

        //Podstawowe informacje dotyczące produktu

        //Id
        public int ProductId { get; set; }

        //Nazwa
        public string ProductName { get; set; }

        //Kategoria
        public virtual Category Category { get; set; }

        //Grupa
        public virtual ICollection<ProductGroup> ProductGroups { get; set; }

        //Jednostka miary
        public virtual Unit Unit { get; set; }

        //Waga jednostki miary
        public decimal Weight { get; set; }

        //Zdjęcie
        public string ProductImagePath { get; set; }


        public virtual ICollection<ProductDish> DishProducts { get; set; }


        //Produkty przypisane do poniedziałku
        public virtual ICollection<ProductMonday> MondayProducts { get; set; }

        //Produkty przypisane do wtorku
        public virtual ICollection<ProductTuesday> TuesdayProducts { get; set; }

        //Produkty przypisane do środy
        public virtual ICollection<ProductWednesday> WednesdayProducts { get; set; }

        //Produkty przypisane do czwartku
        public virtual ICollection<ProductThursday> ThursdayProducts { get; set; }

        //Produkty przypisane do piątku
        public virtual ICollection<ProductFriday> FridayProducts { get; set; }

        //Produkty przypisane do soboty
        public virtual ICollection<ProductSaturday> SaturdayProducts { get; set; }

        //Produkty przypisane do niedzieli
        public virtual ICollection<ProductSunday> SundayProducts { get; set; }

    }
}
