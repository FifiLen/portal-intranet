using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Intranet.Models;

[Table("Urlopy")]
public partial class Urlopy
{
    [Key]
    public int Id { get; set; }

    public int PracownikId { get; set; }

    public DateOnly DataOd { get; set; }

    public DateOnly DataDo { get; set; }

    [StringLength(200)]
    public string? Powod { get; set; }

    
    
    public UrlopStatus Status { get; set; } = UrlopStatus.Oczekuje; 

    [ForeignKey("PracownikId")]
    [InverseProperty("Urlopies")]
    public virtual Pracownicy Pracownik { get; set; } = null!;
}



public enum UrlopStatus
{
    Oczekuje,
    Zaakceptowany,
    Odrzucony
}
