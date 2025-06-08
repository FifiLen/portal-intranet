
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models
{
    public enum TypOgloszenia 
    {
        Informacja, 
        Sukces,     
        Ostrzezenie, 
        Niebezpieczenstwo 
    }

    [Table("Ogloszenia")]
    public class Ogloszenie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł ogłoszenia jest wymagany.")]
        [StringLength(150)]
        public string Tytul { get; set; } = string.Empty;

        [Required(ErrorMessage = "Treść ogłoszenia jest wymagana.")]
        [StringLength(1000)]
        public string Tresc { get; set; } = string.Empty;

        [Required]
        public DateTime DataPublikacji { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string? Dzial { get; set; } 

        [Required]
        public TypOgloszenia Typ { get; set; } = TypOgloszenia.Informacja; 

        public bool CzyWazne { get; set; } = false; 
    }
}
