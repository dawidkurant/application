using System.ComponentModel.DataAnnotations;

namespace Papu.Models
{
    public class CreateDishDto
    {
        //Informacje, które może podać klient, aby stworzyć potrawę

        //Nazwa
        //Nazwa jadłospisu jest wymagana
        [Required]
        //Maksymalna długość łańucha nazwy potrawy wynosi 200
        [MaxLength(200)]
        public string DishName { get; set; }

        //Opis
        //Maksymalna długość łańcucha opisu potrawy wynosi 1300
        [MaxLength(1300)]
        public string DishDescription { get; set; }

        //Sposób przygotowania
        //Maksymalna długość łańcucha sposobu przygotowania potrawy wynosi 1300
        [MaxLength(1300)]
        public string MethodOfPeparation { get; set; }

        //Produkty potrawy składającej się z ilu porcji
        //Maksymalna długość łańcucha porcji potrawy wynosi 3
        [Range(0, 999, ErrorMessage = "Rating must between 0 to 999")]
        public int Portions { get; set; }

        //Czas przygotowania w minutach
        //Maksymalna długość łańcucha czasu potrawy wynosi 3
        [Range(0, 999, ErrorMessage = "Rating must between 0 to 999")]
        public int PreparationTime { get; set; }

        //Rodzaj
        //Maksymalna długość łańcucha rodzaju potrawy wynosi 1
        public int[] KindOfId { get; set; }

        //Rozmiar
        //Maksymalna długość łańcucha rozmiaru potrawy wynosi 3
        [Range(0, 999, ErrorMessage = "Rating must between 0 to 999")]
        public int Size { get; set; }

        //Typ
        //Maksymalna długość łańcucha typu potrawy wynosi 1
        public int[] TypeId { get; set; }

        //Zdjęcie
        public string DishImagePath { get; set; }

        //Produkty zawierające się w daniu
        //Maksymalna długość łańcucha id produktu wynosi 3
        public int[] ProductId { get; set; }
    }
}
