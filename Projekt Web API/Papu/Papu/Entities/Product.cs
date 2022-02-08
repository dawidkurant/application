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


        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int MondayId { get; set; }
        public virtual Monday Monday { get; set; }
        public int TuesdayId { get; set; }
        public virtual Tuesday Tuesday { get; set; }
        public int WednesdayId { get; set; }
        public virtual Wednesday Wednesday { get; set; }
        public int ThursdayId { get; set; }
        public virtual Thursday Thursday { get; set; }
        public int FridayId { get; set; }
        public virtual Friday Friday { get; set; }
        public int SaturdayId { get; set; }
        public virtual Saturday Saturday { get; set; }
        public int SundayId { get; set; }
        public virtual Sunday Sunday { get; set; }
    }
}
