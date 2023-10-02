USE [Projeto06]
GO
DROP TABLE IF EXISTS [dbo].[Estudante]

CREATE TABLE [dbo].[Estudante]
(
	[EstudanteId] [int] IDENTITY(1,1) NOT NULL,
	[EstudanteNome] [varchar](50) NOT NULL,
	[EstudanteSobrenome] [varchar](100) NOT NULL,
	[EstudanteRA] [int] NULL,
	[EstudanteEmail] [varchar](30) NULL,
	[EstudanteIdade] [int] NULL,
	[EstudanteFone] [varchar](30) NULL,
	[EstudanteGenero] [varchar](30) NULL,
 CONSTRAINT [pk_estudante] PRIMARY KEY([EstudanteId]))


 insert into [Estudante] ([EstudanteNome], [EstudanteSobrenome],
 [EstudanteRA], [EstudanteEmail], [EstudanteIdade], [EstudanteFone], [EstudanteGenero])
 values ('Douglas', 'Reis', 1, 'dougreis@gmail.com', 20, '1399111999', 'Masc')

 insert into Curso (CursoNome, CursoMensalidade, EstudanteId, EstudanteRA) 
 values ('ASPNET', 1500, 1, 1)


