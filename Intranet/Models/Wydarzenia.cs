
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models
{
    public enum TypWydarzenia 
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

        public DateTime? DataZakonczenia { get; set; } 

        [StringLength(200)]
        public string? Lokalizacja { get; set; } 

        [Required]
        public TypWydarzenia Typ { get; set; } = TypWydarzenia.Spotkanie;

        
        
        
        
    }
}
