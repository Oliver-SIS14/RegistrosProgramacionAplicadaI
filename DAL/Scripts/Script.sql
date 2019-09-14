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
	Balance float
);

go

CREATE TABLE Inscripcion(

	Inscripsionid int primary key identity(1,1),
	Fecha date,
	Estudianteid int,
	Comentarios varchar(max),
	Monto decimal(9,2),
	Balance decimal(9,2),
	Deposito decimal(9,2),
	constraint fEstudianteid foreign key(Estudianteid) references Estudiante (Estudianteid),
)
