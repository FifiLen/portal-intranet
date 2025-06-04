using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Models;

[Table("Pracownicy")]
[Index("Email", Name = "UQ__Pracowni__A9D10534EDF8D5B2", IsUnique = true)]
public partial class Pracownicy
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Imie { get; set; } = null!;

    [StringLength(70)]
    public string Nazwisko { get; set; } = null!;

    [StringLength(100)]
    public string? Stanowisko { get; set; }

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string? NumerTelefonu { get; set; }

    public DateOnly DataZatrudnienia { get; set; }

    public bool Aktywny { get; set; }

    public string HasloHash { get; set; } = null!;

    [StringLength(50)]
    public string Rola { get; set; } = null!;

    [InverseProperty("Pracownik")]
    public virtual ICollection<Harmonogramy> Harmonogramies { get; set; } = new List<Harmonogramy>();

    [InverseProperty("Pracownik")]
    public virtual ICollection<Urlopy> Urlopies { get; set; } = new List<Urlopy>();
    public virtual ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
}
