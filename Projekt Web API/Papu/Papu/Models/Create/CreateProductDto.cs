using Papu.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Papu.Models
{
    public class CreateProductDto
    {
        //Informacje, które może podać klient, aby stworzyć produkt

        //Nazwa produktu
        public string ProductName { get; set; }

        //Nazwa kategorii
        public string CategoryName { get; set; }

        //Id grupy
        public int[] GroupId { get; set; }

        //Nazwa jednostki
        public string UnitName { get; set; }

        //Waga jednostki miary
        public decimal Weight { get; set; }

        //Zdjęcie
        public string ProductImagePath { get; set; }
    }
}
