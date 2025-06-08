
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models
{
    public enum PriorytetZadania
    {
        Niski,
        Normalny,
        Wysoki,
        Krytyczny
    }

    [Table("Zadania")]
    public class Zadanie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł zadania jest wymagany.")]
        [StringLength(200)]
        public string Tytul { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Opis { get; set; }

        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;

        public DateTime? TerminWykonania { get; set; } 

        public bool CzyWykonane { get; set; } = false;

        public DateTime? DataWykonania { get; set; } 

        [Required]
        public PriorytetZadania Priorytet { get; set; } = PriorytetZadania.Normalny;

        
        [Required(ErrorMessage = "Zadanie musi być przypisane do pracownika.")]
        public int PracownikId { get; set; } 

        [ForeignKey("PracownikId")]
        public virtual Pracownicy PrzypisanyPracownik { get; set; } = null!; 
    }
}
