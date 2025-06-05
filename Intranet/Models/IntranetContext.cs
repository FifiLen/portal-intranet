using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Models; // Poprawna przestrzeń nazw

public partial class IntranetContext : DbContext
{
    // Domyślny konstruktor jest OK, jeśli narzędzia go wymagają lub jeśli tworzysz instancje bez DI
    public IntranetContext()
    {
    }

    // Ten konstruktor jest kluczowy dla wstrzykiwania zależności (Dependency Injection)
    // i przekazywania opcji (w tym connection stringa) z Program.cs
    public IntranetContext(DbContextOptions<IntranetContext> options)
        : base(options)
    {
    }

    // Twoje DbSet-y - wyglądają poprawnie
    public virtual DbSet<Harmonogramy> Harmonogramies { get; set; }
    public virtual DbSet<Pracownicy> Pracownicies { get; set; }
    public virtual DbSet<Urlopy> Urlopies { get; set; }

    public virtual DbSet<Produkt> Produkty { get; set; }
    public virtual DbSet<Zamowienie> Zamowienia { get; set; }
    public virtual DbSet<PozycjaZamowienia> PozycjeZamowien { get; set; }
    public virtual DbSet<Ogloszenie> Ogloszenia { get; set; }

    public virtual DbSet<Zadanie> Zadania { get; set; }
    public virtual DbSet<Wydarzenie> Wydarzenia
    {
        get; set;
    }

    public virtual DbSet<PortalText> PortalTexts { get; set; }

    // METODA ONCONFIGURING ZOSTAŁA USUNIĘTA LUB JEJ ZAWARTOŚĆ ZAKOMENTOWANA
    // Poniżej przykład z całkowicie usuniętą metodą:
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // Nic tutaj nie robimy, konfiguracja połączenia przychodzi z Program.cs
    // }
    // Jeśli chcesz zostawić metodę, ale pustą, to też jest OK.
    // Najprościej jest ją całkowicie usunąć, jeśli nie ma w niej innej logiki.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfiguracja modeli za pomocą Fluent API - wygląda poprawnie
        modelBuilder.Entity<Harmonogramy>(entity =>
        {
            // Scaffolding często dodaje .HasName() dla kluczy, jeśli nazwa ograniczenia w bazie jest niestandardowa.
            // Jeśli nazwa klucza w bazie jest standardowa, .HasName() może nie być konieczne.
            entity.HasKey(e => e.Id).HasName("PK__Harmonog__3214EC074E1BEB35");

            // Definicja relacji: Harmonogramy ma jednego Pracownika, Pracownik ma wiele Harmonogramies.
            // .HasConstraintName() jest dodawane, jeśli nazwa klucza obcego w bazie jest niestandardowa.
            entity.HasOne(d => d.Pracownik).WithMany(p => p.Harmonogramies).HasConstraintName("FK_Harmonogramy_Pracownicy");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pracowni__3214EC07E6B03D7C");

            entity.Property(e => e.Aktywny).HasDefaultValue(true);
            entity.Property(e => e.DataZatrudnienia).HasDefaultValueSql("(CONVERT([date],getdate()))");
        });

        modelBuilder.Entity<Urlopy>(entity =>
        {
            // Dla Urlopy nie ma tu .HasKey(), ponieważ [Key] jest prawdopodobnie w modelu Urlopy.cs.
            // Jeśli klucz główny w tabeli Urlopy nazywa się inaczej niż "Id" lub ma niestandardową nazwę ograniczenia,
            // to konfiguracja .HasKey() mogłaby się tu pojawić.
            entity.HasOne(d => d.Pracownik).WithMany(p => p.Urlopies).HasConstraintName("FK_Urlopy_Pracownicy");
        });


        modelBuilder.Entity<Zamowienie>(entity =>
        {
            entity.Property(e => e.Status)
                  .HasConversion<string>() // Przechowuj enum StatusZamowienia jako string
                  .HasMaxLength(50);
        });

        modelBuilder.Entity<PozycjaZamowienia>(entity =>
        {
            // Klucz złożony dla tabeli łączącej nie jest tu konieczny, bo mamy własne Id,
            // ale definiujemy relacje:
            entity.HasOne(d => d.Zamowienie)
                .WithMany(p => p.PozycjeZamowien)
                .HasForeignKey(d => d.ZamowienieId)
                .OnDelete(DeleteBehavior.Cascade); // Jeśli usuniesz zamówienie, usuń jego pozycje

            entity.HasOne(d => d.Produkt)
                .WithMany(p => p.PozycjeZamowien)
                .HasForeignKey(d => d.ProduktId)
                .OnDelete(DeleteBehavior.Restrict); // Nie pozwól usunąć produktu, jeśli jest w jakimś zamówieniu
                                                    // (lub Cascade, jeśli chcesz usunąć pozycje)
        });

        modelBuilder.Entity<Ogloszenie>(entity =>
        {
            entity.Property(e => e.Typ)
                  .HasConversion<string>() // Przechowuj enum TypOgloszenia jako string
                  .HasMaxLength(50);
        });

        modelBuilder.Entity<Zadanie>(entity =>
        {
            entity.Property(e => e.Priorytet)
                  .HasConversion<string>() // Przechowuj enum PriorytetZadania jako string
                  .HasMaxLength(50);

            // Definicja relacji z Pracownikiem (jeden pracownik ma wiele zadań)
            entity.HasOne(d => d.PrzypisanyPracownik)
                  .WithMany(p => p.Zadania) // Odwołanie do kolekcji Zadania w klasie Pracownicy
                  .HasForeignKey(d => d.PracownikId)
                  .OnDelete(DeleteBehavior.Cascade); // Zgodnie z definicją w SQL
        });

        modelBuilder.Entity<Wydarzenie>(entity =>
        {
            entity.Property(e => e.Typ)
                  .HasConversion<string>() // Przechowuj enum TypWydarzenia jako string
                  .HasMaxLength(50);
        });

        modelBuilder.Entity<PortalText>(entity =>
        {
            entity.Property(e => e.Section)
                  .HasMaxLength(100);
            entity.HasIndex(e => new { e.Key, e.Section }).IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    // Definicja metody częściowej - implementacja może (ale nie musi) być w innym pliku.
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
