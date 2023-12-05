using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Models
{
    public class UpdateProductDto
    {
        // Informacje, które może podać klient, aby stworzyć produkt

        // Nazwa produktu
        [Required]
        // Maksymalna długość łańcucha nazwy produktu wynosi 50
        [MaxLength(50)]
        public string ProductName { get; set; }

        // Nazwa kategorii
        // Maksymalna długość łańcucha nazwy kategorii wynosi 50
        [MaxLength(50)]
        public string CategoryName { get; set; }

        // Id grupy
        public int[] GroupId { get; set; }

        // Nazwa jednostki
        // Maksymalna długość łańcucha nazwy jednostki wynosi 50
        [MaxLength(50)]
        public string UnitName { get; set; }

        // Waga jednostki miary
        // Maksymalna długość łańcucha jednostki miary wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Weight { get; set; }

        // Żelazo
        // Maksymalna długość łańcucha żelaza wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Iron { get; set; }

        // Witamina B12
        // Maksymalna długość łańcucha witaminy B12 wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal VitaminB12 { get; set; }

        // Foliany
        // Maksymalna długość łańcucha folian wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Folate { get; set; }

        // Witamina D
        // Maksymalna długość łańcucha witaminy D wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal VitaminD { get; set; }

        // Wapń
        // Maksymalna długość łańcucha wapna wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Calcium { get; set; }

        // Magnez
        // Maksymalna długość łańcucha magnezu wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Magnesium { get; set; }

        // Błonnik
        // Maksymalna długość łańcucha błonnika wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Fiber { get; set; }

        // Białko
        // Maksymalna długość łańcucha białka wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Protein { get; set; }

        // Tłuszcz
        // Maksymalna długość łańcucha tłuszczu wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Fat { get; set; }

        // Węglowodany przyswajalne
        // Maksymalna długość łańcucha węglowodanów przyswajalnych wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal AssimilableCarbohydrates { get; set; }

        // Wymiennik węglowodanowy
        // Maksymalna długość łańcucha wymiennika węglowodanowego wynosi 4
        [Range(0, 9999, ErrorMessage = "Rating must between 0 to 9999")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal CarbohydrateReplacement { get; set; }

        // Zdjęcie
        public string ProductImagePath { get; set; }
    }
}
