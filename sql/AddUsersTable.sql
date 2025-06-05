CREATE TABLE Uzytkownicy (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Imie NVARCHAR(50) NOT NULL,
    Nazwisko NVARCHAR(70) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    NumerTelefonu NVARCHAR(20) NULL,
    HasloHash NVARCHAR(100) NOT NULL
);

ALTER TABLE Zamowienia
    ADD UzytkownikId INT NULL CONSTRAINT FK_Zamowienia_Uzytkownicy
        FOREIGN KEY REFERENCES Uzytkownicy(Id) ON DELETE SET NULL;

INSERT INTO Uzytkownicy (Imie, Nazwisko, Email, NumerTelefonu, HasloHash)
VALUES ('Jan', 'Kowalski', 'jan@example.com', '123456789', 'tajne');
