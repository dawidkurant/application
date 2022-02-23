using Papu.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Papu.Models
{
    public class CreateProductDto
    {
        //Podstawowe informacje dotyczące produktu dostępne dla klienta

        //Nazwa produktu
        public string ProductName { get; set; }

        //Id grupy
        public int[] GroupId { get; set; }

        //Nazwa kategorii
        public string CategoryName { get; set; }

        //Nazwa jednostki
        public string UnitName { get; set; }

        //Waga jednostki miary
        public decimal Weight { get; set; }

        //Zdjęcie
        public string ProductImagePath { get; set; }
    }
}
