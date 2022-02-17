using Papu.Entities;
using System.Collections.Generic;

namespace Papu.Models
{
    public class ProductDto
    {
        //Podstawowe informacje dotyczące produktu dostępne dla klienta

        //Id
        public int ProductId { get; set; }

        //Nazwa
        public string Name { get; set; }

        //Kategoria
        public string CategoryName { get; set; }

        //Grupa
        public virtual List<Group> Groups { get; set; }

        //Jednostka miary
        public string UnitName { get; set; }

        //Waga jednostki miary
        public decimal Weight { get; set; }
    }
}
