using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Models; 

public partial class IntranetContext : DbContext
{
    
    public IntranetContext()
    {
    }

    
    
    public IntranetContext(DbContextOptions<IntranetContext> options)
        : base(options)
    {
    }

    
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
    public virtual DbSet<Uzytkownik> Uzytkownicy { get; set; }

    
    
    
    
    
    
    
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Harmonogramy>(entity =>
        {
            
            
            entity.HasKey(e => e.Id).HasName("PK__Harmonog__3214EC074E1BEB35");

            
            
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
            
            
            
            entity.HasOne(d => d.Pracownik).WithMany(p => p.Urlopies).HasConstraintName("FK_Urlopy_Pracownicy");
        });


        modelBuilder.Entity<Zamowienie>(entity =>
        {
            entity.Property(e => e.Status)
                  .HasConversion<string>() 
                  .HasMaxLength(50);
        });

        modelBuilder.Entity<PozycjaZamowienia>(entity =>
        {
            
            
            entity.HasOne(d => d.Zamowienie)
                .WithMany(p => p.PozycjeZamowien)
                .HasForeignKey(d => d.ZamowienieId)
                .OnDelete(DeleteBehavior.Cascade); 

            entity.HasOne(d => d.Produkt)
                .WithMany(p => p.PozycjeZamowien)
                .HasForeignKey(d => d.ProduktId)
                .OnDelete(DeleteBehavior.Restrict); 
                                                    
        });

        modelBuilder.Entity<Ogloszenie>(entity =>
        {
            entity.Property(e => e.Typ)
                  .HasConversion<string>() 
                  .HasMaxLength(50);
        });

        modelBuilder.Entity<Zadanie>(entity =>
        {
            entity.Property(e => e.Priorytet)
                  .HasConversion<string>() 
                  .HasMaxLength(50);

            
            entity.HasOne(d => d.PrzypisanyPracownik)
                  .WithMany(p => p.Zadania) 
                  .HasForeignKey(d => d.PracownikId)
                  .OnDelete(DeleteBehavior.Cascade); 
        });

        modelBuilder.Entity<Wydarzenie>(entity =>
        {
            entity.Property(e => e.Typ)
                  .HasConversion<string>() 
                  .HasMaxLength(50);
        });

        modelBuilder.Entity<PortalText>(entity =>
        {
            entity.Property(e => e.Section)
                  .HasMaxLength(100);
            entity.HasIndex(e => new { e.Key, e.Section }).IsUnique();
        });

        modelBuilder.Entity<Uzytkownik>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
