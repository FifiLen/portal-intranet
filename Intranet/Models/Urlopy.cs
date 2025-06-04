using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore; // Prawdopodobnie niepotrzebne bezpośrednio tutaj

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

    // POPRAWIONA WŁAŚCIWOŚĆ STATUS:
    // Usunięto [StringLength(50)] - nie jest potrzebne dla enuma tutaj
    public UrlopStatus Status { get; set; } = UrlopStatus.Oczekuje; // Typ to UrlopStatus, domyślna wartość

    [ForeignKey("PracownikId")]
    [InverseProperty("Urlopies")]
    public virtual Pracownicy Pracownik { get; set; } = null!;
}

// Definicja enuma UrlopStatus (może być w tym samym pliku lub w osobnym Models/UrlopStatus.cs)
// Jeśli jest w tym samym pliku, upewnij się, że jest tylko jedna definicja namespace Intranet.Models na górze pliku.
public enum UrlopStatus
{
    Oczekuje,
    Zaakceptowany,
    Odrzucony
}
