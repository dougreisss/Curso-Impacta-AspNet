use Projeto06
go
drop table if exists Curso

create table Curso
(
	CursoId int identity(1,1), 
	CursoNome varchar(100),
	CursoMensalidade float,
	EstudanteId int, 
	EstudanteRA int,
	constraint pk_curso primary key (CursoId),
	constraint fk_curso_estudante foreign key (EstudanteId)
	references Estudante (EstudanteId)
)

