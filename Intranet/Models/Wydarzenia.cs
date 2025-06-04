// W Models/Wydarzenie.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models
{
    public enum TypWydarzenia // Możesz chcieć różne typy dla kolorowania itp.
    {
        Spotkanie,
        Szkolenie,
        Inwentaryzacja,
        Konferencja,
        Firmowe,
        Inne
    }

    [Table("Wydarzenia")]
    public class Wydarzenie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa wydarzenia jest wymagana.")]
        [StringLength(200)]
        public string Nazwa { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Opis { get; set; }

        [Required]
        public DateTime DataRozpoczecia { get; set; }

        public DateTime? DataZakonczenia { get; set; } // Może być opcjonalne, jeśli wydarzenie jest jednodniowe/jednogodzinne

        [StringLength(200)]
        public string? Lokalizacja { get; set; } // Np. "Sala konferencyjna", "Online", "Magazyn"

        [Required]
        public TypWydarzenia Typ { get; set; } = TypWydarzenia.Spotkanie;

        // Możesz dodać pole dla organizatora lub uczestników, jeśli potrzebujesz
        // public int? OrganizatorId { get; set; }
        // public virtual Pracownicy Organizator { get; set; }
        // public virtual ICollection<Pracownicy> Uczestnicy { get; set; }
    }
}
