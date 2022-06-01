using Microsoft.AspNetCore.Http;
using Papu.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Models
{
    public class ProductDto
    {
        //Podstawowe informacje dotyczące produktu dostępne dla klienta

        //Id
        public int ProductId { get; set; }

        //Nazwa
        public string ProductName { get; set; }

        //Kategoria
        public string CategoryName { get; set; }

        //Grupa
        public virtual ICollection<Group> Groups { get; set; }

        //Jednostka miary
        public string UnitName { get; set; }

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
    }
}
