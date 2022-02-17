using System.Collections.Generic;

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
        public virtual List<Group> Groups { get; set; }

        //Jednostka miary
        public virtual Unit Unit { get; set; }

        //Waga jednostki miary
        public decimal Weight { get; set; }


        public virtual Dish Dish { get; set; }
    }
}
