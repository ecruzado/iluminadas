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