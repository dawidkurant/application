using System.Collections.Generic;

namespace Papu.Entities
{
    public class Product
    {
        //Podstawowe informacje dotyczące produktu

        //Id
        public int Id { get; set; }

        //Nazwa
        public string Name { get; set; }

        //Grupa
        public List<Group> Groups { get; set; }

        //Jednostka miary
        public List<Unit> Units { get; set; }

        //Waga jednostki miary
        public double Weight { get; set; }
    }
}
