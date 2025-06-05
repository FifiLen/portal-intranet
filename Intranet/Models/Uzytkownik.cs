using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Models;

[Table("Uzytkownicy")]
[Index(nameof(Email), IsUnique = true)]
public class Uzytkownik
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Imie { get; set; } = string.Empty;

    [StringLength(70)]
    public string Nazwisko { get; set; } = string.Empty;

    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [StringLength(20)]
    public string? NumerTelefonu { get; set; }

    [StringLength(100)]
    public string HasloHash { get; set; } = string.Empty;

    [InverseProperty(nameof(Zamowienie.Uzytkownik))]
    public virtual ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
}
