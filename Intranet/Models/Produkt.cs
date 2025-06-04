using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models
{
    [Table("Produkty")]
    public class Produkt
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
        [StringLength(200)]
        public string Nazwa { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Opis { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Column(TypeName = "decimal(18, 2)")] // Dla precyzji walutowej
        [Range(0.01, 1000000, ErrorMessage = "Cena musi być większa niż 0.")]
        public decimal Cena { get; set; }

        [StringLength(100)]
        public string? Kategoria { get; set; }

        [Required(ErrorMessage = "Stan magazynowy jest wymagany.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stan magazynowy nie może być ujemny.")]
        public int StanMagazynowy { get; set; }

        // Właściwość nawigacyjna dla pozycji zamówień
        public virtual ICollection<PozycjaZamowienia> PozycjeZamowien { get; set; } = new List<PozycjaZamowienia>();
    }
}
