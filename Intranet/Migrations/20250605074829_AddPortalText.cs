using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intranet.Migrations
{
    /// <inheritdoc />
    public partial class AddPortalText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogloszenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DataPublikacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dzial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Typ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CzyWazne = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogloszenia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortalTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Stanowisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DataZatrudnienia = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(CONVERT([date],getdate()))"),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    HasloHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pracowni__3214EC07E6B03D7C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kategoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StanMagazynowy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydarzenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lokalizacja = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Typ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydarzenia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZlozenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImieZamawiajacego = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NazwiskoZamawiajacego = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailZamawiajacego = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LacznaWartosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Harmonogramy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracownikId = table.Column<int>(type: "int", nullable: false),
                    DataZmiany = table.Column<DateOnly>(type: "date", nullable: false),
                    GodzRozpoczecia = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    GodzZakonczenia = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TypZmiany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Harmonog__3214EC074E1BEB35", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harmonogramy_Pracownicy",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urlopy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracownikId = table.Column<int>(type: "int", nullable: false),
                    DataOd = table.Column<DateOnly>(type: "date", nullable: false),
                    DataDo = table.Column<DateOnly>(type: "date", nullable: false),
                    Powod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urlopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urlopy_Pracownicy",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zadania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminWykonania = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CzyWykonane = table.Column<bool>(type: "bit", nullable: false),
                    DataWykonania = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priorytet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PracownikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zadania_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PozycjeZamowien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZamowienieId = table.Column<int>(type: "int", nullable: false),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    CenaJednostkowa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjeZamowien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PozycjeZamowien_Produkty_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PozycjeZamowien_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogramy_PracownikId",
                table: "Harmonogramy",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalTexts_Key_Language",
                table: "PortalTexts",
                columns: new[] { "Key", "Language" },
                unique: true,
                filter: "[Language] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamowien_ProduktId",
                table: "PozycjeZamowien",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamowien_ZamowienieId",
                table: "PozycjeZamowien",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "UQ__Pracowni__A9D10534EDF8D5B2",
                table: "Pracownicy",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urlopy_PracownikId",
                table: "Urlopy",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadania_PracownikId",
                table: "Zadania",
                column: "PracownikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harmonogramy");

            migrationBuilder.DropTable(
                name: "Ogloszenia");

            migrationBuilder.DropTable(
                name: "PortalTexts");

            migrationBuilder.DropTable(
                name: "PozycjeZamowien");

            migrationBuilder.DropTable(
                name: "Urlopy");

            migrationBuilder.DropTable(
                name: "Wydarzenia");

            migrationBuilder.DropTable(
                name: "Zadania");

            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Pracownicy");
        }
    }
}
