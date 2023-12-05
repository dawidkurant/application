using System.Collections.Generic;

namespace Papu.Entities
{
    public class Dish
    {
        // Podstawowe informacje dotyczące potrawy

        // Id
        public int DishId { get; set; }

        // Nazwa
        public string DishName { get; set; }

        // Opis
        public string DishDescription { get; set; }

        // Sposób przygotowania
        public string MethodOfPeparation { get; set; }

        // Produkty potrawy składającej się z ilu porcji
        public int Portions { get; set; }

        // Czas przygotowania w minutach
        public int PreparationTime { get; set; }

        // Rodzaj
        public virtual ICollection<DishKindOf> DishKindsOf { get; set; }

        // Rozmiar
        public int Size { get; set; }

        // Typ
        public virtual ICollection<DishType> DishTypes { get; set; }

        // Zdjęcie
        public string DishImagePath { get; set; }

        // Twórca danej potrawy
        public int? CreatedById { get; set; }

        // Zmienna reperezentująca twórcę danej potrawy
        public virtual User CreatedBy { get; set; }

        // Produkty zawierające się w daniu
        public virtual ICollection<ProductDish> DishProducts { get; set; }

        // Pory dnia w których zawiera się potrawa
        public virtual ICollection<DishMeal> DishMeals { get; set; }
    }
}
