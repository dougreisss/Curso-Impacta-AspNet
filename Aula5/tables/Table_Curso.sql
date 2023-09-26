use Projeto06
go
drop table if exists Curso

create table Curso
(
	Curso_Id int identity(1,1), 
	Curso_Nome varchar(100),
	Curso_Mensalidade decimal(10,2),
	Estudante_Id int, 
	Estudante_RA int,
	constraint pk_curso primary key (Estudante_Id),
	constraint fk_curso_estudante foreign key (Estudante_Id)
	references Estudante (Estudante_Id)
)

