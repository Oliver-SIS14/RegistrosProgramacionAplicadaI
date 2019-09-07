CREATE DATABASE EstudiantesDb

GO

USE EstudiantesDb

CREATE TABLE Estudiante
(
	Estudianteid int primary key identity(1,1),
	Matricula varchar(9),
	Nombres varchar(30),
	Apellidos varchar(30),
	Cedula varchar(13),
	Telefono varchar(10),
	Celular varchar(10),
	Email varchar(30),
	FechaNacimiento date,
	Sexo int,
	Balance decimal
);