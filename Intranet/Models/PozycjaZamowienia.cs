using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models
{
    [Table("PozycjeZamowien")]
    public class PozycjaZamowienia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ZamowienieId { get; set; }
        public virtual Zamowienie Zamowienie { get; set; } = null!;

        [Required]
        public int ProduktId { get; set; }
        public virtual Produkt Produkt { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Ilość musi być większa niż 0.")]
        public int Ilosc { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CenaJednostkowa { get; set; } // Cena produktu w momencie zakupu
    }
}
