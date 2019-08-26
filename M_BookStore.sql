CREATE DATABASE M_BookStore;

USE M_BookStore;


CREATE TABLE Generos
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Genero  VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Autores 
(
    IdAutor             INT PRIMARY KEY IDENTITY
    ,Nome               VARCHAR(200)
    ,Email              VARCHAR(255) UNIQUE
    ,Ativo              BIT DEFAULT(1) -- BIT/CHAR
    ,DataNascimento     DATE
);

CREATE TABLE Livros
(
    IdLivro             INT PRIMARY KEY IDENTITY
    ,Livro          VARCHAR(255) NOT NULL UNIQUE
    ,IdAutor            INT FOREIGN KEY REFERENCES Autores (IdAutor)
    ,IdGenero           INT FOREIGN KEY REFERENCES Generos (IdGenero)
	);

insert into Generos (Genero) values('Terror'),('Romance')

insert into Autores (Nome,Email,DataNascimento) values ('Stephen King','stephen@gmail.com','1980-04-24'),('Agatha Christie','agatha@gmail.com','1950-10-02')

insert into Livros (Livro,IdAutor,IdGenero)values ('It a Coisa',1,1)

select * from Generos order by IdGenero asc
select * from Autores order by IdAutor asc
select * from Livros order by IdLivro asc

select Livros.IdLivro, Livros.Livro, Generos.Genero, Autores.Nome from Livros join Generos on Livros.IdGenero = Generos.IdGenero join Autores on Livros.IdAutor = Autores.IdAutor
update Livros set IdGenero = 3 where IdLivro = 1

select Autores.IdAutor, Autores.Nome, Livros.Livro from Autores join Livros on Autores.IdAutor = Livros.IdAutor  where Livros.IdAutor = 1 @IdAutor
