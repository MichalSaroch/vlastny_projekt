CREATE DATABASE [projekt]
GO

USE [projekt]
GO

CREATE TABLE Zamestnanec (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    meno varchar(100) NOT NULL UNIQUE,
	heslo varchar(100) NOT NULL,
	salt varchar(100) NOT NULL
);

CREATE TABLE Osoba (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    meno varchar(100) NOT NULL,
	priezvisko varchar(100) NOT NULL,
	datum_narodenia date,
	mesto varchar(100),
	adresa varchar(100),
	psc varchar(20),
	telefonne_cislo varchar(20)
);

CREATE TABLE Zamestnanec_udaje (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ID_Zamestnanec int NOT NULL FOREIGN KEY REFERENCES Zamestnanec(ID),
	meno varchar(100),
	priezvisko varchar(100),
	datum_narodenia date,
	mesto varchar(100),
	adresa varchar(100),
	psc varchar(20),
	telefonne_cislo varchar(20)
);

CREATE TABLE Vyrobca (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	meno varchar(100) NOT NULL UNIQUE
);

CREATE TABLE Produkty (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ID_vyrobca int NOT NULL FOREIGN KEY REFERENCES Vyrobca(ID),
	nazov varchar(100) NOT NULL UNIQUE,
	cena decimal(10,2) NOT NULL,
	dostupne BIT
);

CREATE TABLE Transakcie_Typ (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nazov varchar(100) NOT NULL UNIQUE
);

CREATE TABLE Transakcie (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ID_Zamestnanec int NOT NULL FOREIGN KEY REFERENCES Zamestnanec(ID),
	ID_Osoba int NOT NULL FOREIGN KEY REFERENCES Osoba(ID),
	ID_Typ int NOT NULL FOREIGN KEY REFERENCES Transakcie_Typ(ID)
);

CREATE TABLE Transakcie_Produkty (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ID_Produkty int NOT NULL FOREIGN KEY REFERENCES Produkty(ID)
	ID_Transakcie int NOT NULL FOREIGN KEY REFERENCES Transakcie(ID)
);