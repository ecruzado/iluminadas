USE [Iluminada]
GO

create proc sp_clase_insert 
	@ColegioId int
    ,@Profesor nvarchar(500) = null
    ,@AreaId int
    ,@NivelId int
    ,@GradoId int
    ,@CompetenciaLvId int
    ,@CapacidadLvId int
    ,@MetodologiaLvId int
    ,@TituloId int
    ,@TemaId int
    ,@Contenido nvarchar(500) = null
    ,@Competencia nvarchar(max) = null
    ,@Capacidad nvarchar(max) = null
    ,@TemaContenido nvarchar(max) = null
    ,@VirtudGeneralId int 
    ,@VirtudEspecificaId int
    ,@Indicador nvarchar(max) = null
	,@new_identity bigint = NULL OUTPUT

as
begin

INSERT INTO [dbo].[Clase]
           ([ColegioId]
           ,[Profesor]
           ,[AreaId]
           ,[NivelId]
           ,[GradoId]
           ,[CompetenciaLvId]
           ,[CapacidadLvId]
           ,[MetodologiaLvId]
           ,[TituloId]
           ,[TemaId]
           ,[Contenido]
           ,[Competencia]
           ,[Capacidad]
           ,[TemaContenido]
           ,[VirtudGeneralId]
           ,[VirtudEspecificaId]
           ,[Indicador])
     VALUES
           (@ColegioId
           ,@Profesor
           ,@AreaId
           ,@NivelId
           ,@GradoId
           ,@CompetenciaLvId
           ,@CapacidadLvId
           ,@MetodologiaLvId
           ,@TituloId
           ,@TemaId
           ,@Contenido
           ,@Competencia
           ,@Capacidad
           ,@TemaContenido
           ,@VirtudGeneralId
           ,@VirtudEspecificaId
           ,@Indicador)

SET @new_identity = SCOPE_IDENTITY();

end

go

create proc sp_clase_update
	@ClaseId bigint
	,@ColegioId int
    ,@Profesor nvarchar(500)
    ,@AreaId int
    ,@NivelId int
    ,@GradoId int
    ,@CompetenciaLvId int
    ,@CapacidadLvId int
    ,@MetodologiaLvId int
    ,@TituloId int
    ,@TemaId int
    ,@Contenido nvarchar(500)
    ,@Competencia nvarchar(max)
    ,@Capacidad nvarchar(max)
    ,@TemaContenido nvarchar(max)
    ,@VirtudGeneralId int
    ,@VirtudEspecificaId int
    ,@Indicador nvarchar(max)
	,@new_identity INT = NULL OUTPUT

as
begin

update [dbo].[Clase]
    set [ColegioId] = @ColegioId
           ,[Profesor] = @Profesor
           ,[AreaId] = @AreaId
           ,[NivelId] = @NivelId
           ,[GradoId] = @GradoId
           ,[CompetenciaLvId] = @CompetenciaLvId
           ,[CapacidadLvId] = @CapacidadLvId
           ,[MetodologiaLvId] = @MetodologiaLvId
           ,[TituloId] = @TituloId
           ,[TemaId] = @TemaId
           ,[Contenido] = @Contenido
           ,[Competencia] = @Competencia
           ,[Capacidad] = @Capacidad
           ,[TemaContenido] = @TemaContenido
           ,[VirtudGeneralId] = @VirtudGeneralId
           ,[VirtudEspecificaId] = @VirtudEspecificaId
           ,[Indicador] = @Indicador
where ClaseId = @ClaseId

end

go

create proc sp_clase_getById
	@ClaseId bigint
as
begin

select *
from dbo.Clase c
where c.ClaseId = @ClaseId

end
go

create proc sp_clase_search
	@ClaseId bigint
	,@ColegioId int
    ,@Profesor nvarchar(500)
    ,@AreaId int
    ,@NivelId int
    ,@GradoId int
    ,@CompetenciaLvId int
    ,@CapacidadLvId int
    ,@MetodologiaLvId int
    ,@TituloId int
    ,@TemaId int
    ,@Contenido nvarchar(500)
    ,@Competencia nvarchar(max)
    ,@Capacidad nvarchar(max)
    ,@TemaContenido nvarchar(max)
    ,@VirtudGeneralId int
    ,@VirtudEspecificaId int
    ,@Indicador nvarchar(max)
	,@new_identity INT = NULL OUTPUT

as
begin

select *
from dbo.Clase c
where CASE 
		WHEN @ClaseId IS NULL THEN 1
		WHEN c.ClaseId = @ClaseId THEN 1
		ELSE 0
	END = 1 
	AND CASE
		WHEN @ColegioId IS NULL THEN 1
		WHEN c.ColegioId = @ColegioId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Profesor IS NULL THEN 1
		WHEN c.Profesor like @Profesor+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @AreaId IS NULL THEN 1
		WHEN c.AreaId = @AreaId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @NivelId IS NULL THEN 1
		WHEN c.NivelId = @NivelId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @GradoId IS NULL THEN 1
		WHEN c.GradoId = @GradoId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @CompetenciaLvId IS NULL THEN 1
		WHEN c.CompetenciaLvId = @CompetenciaLvId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @CapacidadLvId IS NULL THEN 1
		WHEN c.CapacidadLvId = @CapacidadLvId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @MetodologiaLvId IS NULL THEN 1
		WHEN c.MetodologiaLvId = @MetodologiaLvId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @TituloId IS NULL THEN 1
		WHEN c.TituloId = @TituloId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @TemaId IS NULL THEN 1
		WHEN c.TemaId = @TemaId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Contenido IS NULL THEN 1
		WHEN c.Contenido like @Contenido+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Competencia IS NULL THEN 1
		WHEN c.Competencia like @Competencia+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Capacidad IS NULL THEN 1
		WHEN c.Capacidad like @Capacidad+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @TemaContenido IS NULL THEN 1
		WHEN c.TemaContenido like @TemaContenido+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @VirtudGeneralId IS NULL THEN 1
		WHEN c.VirtudGeneralId = @VirtudGeneralId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @VirtudEspecificaId IS NULL THEN 1
		WHEN c.VirtudEspecificaId = @VirtudEspecificaId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Indicador IS NULL THEN 1
		WHEN c.Indicador like @Indicador+'%' THEN 1
		ELSE 0
	END = 1
ORDER BY c.ClaseId DESC

end

go
