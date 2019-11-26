CREATE DATABASE [AccentureAcademyLibreria.Sql]
GO

USE [AccentureAcademyLibreria.Sql]
GO

CREATE TABLE Genero
(
    Id int primary key identity(1,1),
    Nombre varchar(50) not null,
    Descripcion varchar(100) not null,
    CONSTRAINT UQ_GENERO_NOMBRE UNIQUE (Nombre),

);
GO

CREATE TABLE Autor
(
    Id int primary key identity(1,1),
    Nombre varchar(50) not null,
    Apellido varchar(50) not null,
    FechaNacimiento DateTime not null,
    CONSTRAINT UQ_AUTOR_NOMBRE_APELLIDO UNIQUE (Nombre, Apellido)
    
);
GO

CREATE TABLE Editorial
(
    Id int primary key identity(1,1),
    Nombre varchar(50) not null,
    Cuil varchar(11) not null,
    Email varchar(75) not null,
    CONSTRAINT UQ_EDITORIAL_CUIL UNIQUE (Cuil),
    CONSTRAINT UQ_EDITORIAL_NOMBRE UNIQUE (Nombre),
    CONSTRAINT CK_EDITORIAL_CUIL CHECK (Cuil LIKE '[0-9]%'),
    CONSTRAINT CK_EDITORIAL_EMAIL CHECK (Email LIKE '%___@___%')
);
GO

CREATE TABLE Libro
(
    Id int primary key identity(1,1),
    Nombre varchar(50) not null,
    AnioPublicacion DateTime not null,
    NroPaginas int not null,
	ISBN varchar(22) not null,
	Id_Editorial int not null,
	CONSTRAINT UQ_LIBRO_ISBN UNIQUE (ISBN),
    CONSTRAINT CK_LIBRO_NROPAGINAS CHECK (NroPaginas > 0),
	CONSTRAINT FK_LIBRO_EDITORIAL FOREIGN KEY (Id_Editorial)
		REFERENCES Editorial(Id)
		ON DELETE CASCADE
);
GO



CREATE TABLE Pertenece
(
	Id int primary key identity(1,1),
    Id_Libro int not null,
    Id_Genero int not null,
	CONSTRAINT FK_PERTENECE_LIBRO FOREIGN KEY (Id_Libro)
		REFERENCES Libro(Id)
		ON DELETE CASCADE,
	CONSTRAINT FK_PERTENECE_GENERO FOREIGN KEY (Id_Genero)
		REFERENCES Genero(Id)
		ON DELETE CASCADE
);
GO



CREATE TABLE EscritoPor
(
	Id int primary key identity(1,1),
	Id_Autor int not null,
	Id_Libro int not null,
	CONSTRAINT FK_ESCRITOPOR_AUTOR FOREIGN KEY (Id_Autor)
		REFERENCES Autor(Id)
		ON DELETE CASCADE,
	CONSTRAINT FK_ESCRITOPOR_LIBRO FOREIGN KEY (Id_Libro)
		REFERENCES Libro(Id)
		ON DELETE CASCADE,
	CONSTRAINT UQ_ESCRITOPOR_AUTOR_LIBRO UNIQUE (Id_Autor, Id_Libro)
);
GO

INSERT INTO Genero
(Nombre, Descripcion)
VALUES
('Terror', 'da miedo'),
('Suspenso', 'da ansiedad'),
('Comedia', 'da risa')

INSERT INTO Editorial
(Nombre,Cuil,Email)
VALUES
('Editorial1', '20857499963', 'editorial1@gmail.com'),
('Editorial2', '20145877783', 'editorial2@gmail.com'),
('Editorial3', '25478799965', 'editorial3@gmail.com')

INSERT INTO Autor
(Nombre, Apellido, FechaNacimiento)
VALUES
('jorgito', 'martin', '1978-04-21'),
('juan', 'pat', '1980-08-13'),
('stella', 'pari', '1986-03-09')

INSERT INTO Libro
(Nombre, AnioPublicacion, NroPaginas, ISBN, Id_Editorial)
VALUES
('Libro1', '1984-01-01', 285, 'ISBNLIBRO1', 1),
('Libro2', '1976-01-01', 387, 'ISBNLIBRO2', 2),
('Libro3', '1965', 210, 'ISBNLIBRO3', 3)

INSERT INTO Pertenece
(Id_Libro, Id_Genero)
VALUES
(1,1),
(1,3),
(2,3),
(3,1),
(3,2)

INSERT INTO EscritoPor
(Id_Autor, Id_Libro)
VALUES
(1,3),
(2,1),
(2,2),
(3,1)