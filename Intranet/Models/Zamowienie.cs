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

        public int? UzytkownikId { get; set; }

        [ForeignKey(nameof(UzytkownikId))]
        public virtual Uzytkownik? Uzytkownik { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal LacznaWartosc { get; set; } 

        [Required]
        public StatusZamowienia Status { get; set; } = StatusZamowienia.Nowe;

        
        public virtual ICollection<PozycjaZamowienia> PozycjeZamowien { get; set; } = new List<PozycjaZamowienia>();
    }
}
