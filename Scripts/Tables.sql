create table Clase(
	ClaseId bigint identity(1,1),
	ColegioId int,
	Profesor nvarchar(500),
	AreaId int,
	NivelId int,
	GradoId int,
	CompetenciaLvId int,
	CapacidadLvId int,
	MetodologiaLvId int,
	TituloId int,
	TemaId int,
	Contenido nvarchar(500),
	Competencia nvarchar(max),
	Capacidad nvarchar(max),
	TemaContenido nvarchar(max),
	VirtudGeneralId int,
	VirtudEspecificaId int,
	Indicador nvarchar(max),
	CONSTRAINT [PK_clase] PRIMARY KEY CLUSTERED 
	(
		ClaseId ASC
	)
)
GO

create table Tabla(
	NombreTabla nvarchar(50) not null,
	Codigo int not null,
	Valor nvarchar(50) not null,
	CodigoPadre int,
	EsActivo bit not null,
	Valor1 nvarchar(200),
	Valor2 nvarchar(200),
	Valor3 nvarchar(200),
	CONSTRAINT [PK_tabla] PRIMARY KEY CLUSTERED 
	(
		NombreTabla, Codigo
	)
)

GO