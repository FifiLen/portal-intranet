using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models
{
    public enum StatusZamowienia
    {
        Nowe,
        PrzyjeteDoRealizacji,
        WRealizacji,
        Wyslane,
        Zrealizowane,
        Anulowane
    }

    [Table("Zamowienia")]
    public class Zamowienie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataZlozenia { get; set; } = DateTime.UtcNow;

        // Możesz tu dodać IdKlienta, jeśli będziesz miał tabelę Klienci
        // public int? KlientId { get; set; }
        // public virtual Klient Klient { get; set; }

        [Required(ErrorMessage = "Imię zamawiającego jest wymagane.")]
        [StringLength(100)]
        public string ImieZamawiajacego { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nazwisko zamawiającego jest wymagane.")]
        [StringLength(100)]
        public string NazwiskoZamawiajacego { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres email jest wymagany.")]
        [EmailAddress]
        [StringLength(150)]
        public string EmailZamawiajacego { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal LacznaWartosc { get; set; } // Obliczana na podstawie pozycji

        [Required]
        public StatusZamowienia Status { get; set; } = StatusZamowienia.Nowe;

        // Właściwość nawigacyjna dla pozycji zamówień
        public virtual ICollection<PozycjaZamowienia> PozycjeZamowien { get; set; } = new List<PozycjaZamowienia>();
    }
}
