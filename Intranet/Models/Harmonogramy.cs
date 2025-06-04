using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Models;

[Table("Harmonogramy")]
public partial class Harmonogramy
{
    [Key]
    public int Id { get; set; }

    public int PracownikId { get; set; }

    public DateOnly DataZmiany { get; set; }

    [StringLength(5)]
    public string GodzRozpoczecia { get; set; } = null!;

    [StringLength(5)]
    public string GodzZakonczenia { get; set; } = null!;

    [StringLength(50)]
    public string TypZmiany { get; set; } = null!;

    [ForeignKey("PracownikId")]
    [InverseProperty("Harmonogramies")]
    public virtual Pracownicy Pracownik { get; set; } = null!;
}
