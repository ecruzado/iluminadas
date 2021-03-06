create proc sp_clase_insert 
	@ColegioId int
    ,@Profesor nvarchar(500) = null
    ,@Nombre nvarchar(500) = null
    ,@AreaId int = null
    ,@NivelId int = null
    ,@GradoId int = null
    ,@CompetenciaLvId int = null
    ,@CapacidadLvId int = null
    ,@MetodologiaLvId int = null
    ,@TituloId int = null
    ,@TemaId int = null
    ,@Contenido nvarchar(500) = null
    ,@Competencia nvarchar(max) = null
    ,@Capacidad nvarchar(max) = null
    ,@TemaContenido nvarchar(max) = null
    ,@VirtudGeneralId int  = null
    ,@VirtudEspecificaId int = null
    ,@Indicador nvarchar(max) = null
	,@Archivo nvarchar(500) = null
	,@UsuarioCreacion nvarchar(50)
	,@new_identity bigint = NULL OUTPUT

as
begin

INSERT INTO [dbo].[Clase]
           ([ColegioId]
           ,[Profesor]
		   ,[Nombre]
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
           ,[Indicador]
		   ,[Archivo]
		   ,[EsActivo]
		   ,[UsuarioCreacion]
		   ,[FechaCreacion])
     VALUES
           (@ColegioId
           ,@Profesor
		   ,@Nombre
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
           ,@Indicador
		   ,@Archivo
		   ,1
		   ,@UsuarioCreacion
		   ,GETDATE())

SET @new_identity = SCOPE_IDENTITY();

end

go

create proc sp_clase_update
	@ClaseId bigint
	,@ColegioId int = null
    ,@Profesor nvarchar(500) = null
	,@Nombre nvarchar(500) = null
    ,@AreaId int = null
    ,@NivelId int = null
    ,@GradoId int = null
    ,@CompetenciaLvId int = null
    ,@CapacidadLvId int = null
    ,@MetodologiaLvId int = null
    ,@TituloId int = null
    ,@TemaId int = null
    ,@Contenido nvarchar(500) = null
    ,@Competencia nvarchar(max) = null
    ,@Capacidad nvarchar(max) = null
    ,@TemaContenido nvarchar(max) = null
    ,@VirtudGeneralId int = null
    ,@VirtudEspecificaId int = null
    ,@Indicador nvarchar(max) = null
	,@Archivo nvarchar(500) = null
	,@EsActivo bit = NULL
	,@UsuarioModificacion nvarchar(50) = null

as
begin

update [dbo].[Clase]
    set [ColegioId] = @ColegioId
           ,[Profesor] = @Profesor
		   ,[Nombre] = @Nombre
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
		   ,[Archivo] = @Archivo
		   ,[EsActivo] = @EsActivo
		   ,[UsuarioModificacion] = @UsuarioModificacion
		   ,[FechaModificacion] = GETDATE()
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
	@ClaseId bigint = null
	,@ColegioId int = null
    ,@Profesor nvarchar(500) = null
	,@Nombre nvarchar(500) = null
    ,@AreaId int = null
    ,@NivelId int = null
    ,@GradoId int = null
    ,@CompetenciaLvId int = null
    ,@CapacidadLvId int = null
    ,@MetodologiaLvId int = null
    ,@TituloId int = null
    ,@TemaId int = null
    ,@Contenido nvarchar(500) = null
    ,@Competencia nvarchar(max) = null
    ,@Capacidad nvarchar(max) = null
    ,@TemaContenido nvarchar(max) = null
    ,@VirtudGeneralId int = null
    ,@VirtudEspecificaId int = null
    ,@Indicador nvarchar(max) = null
as
begin

select top 200 c.*, co.Valor as 'Colegio', a.Valor as 'Area', n.Valor as 'Nivel', g.Valor as 'Grado'
from dbo.Clase c
inner join Tabla co on co.NombreTabla = 'Colegio' and co.Codigo = c.ColegioId
inner join Tabla a on a.NombreTabla = 'Area' and a.Codigo = c.AreaId
inner join Tabla n on n.NombreTabla = 'Nivel' and n.Codigo = c.NivelId
inner join Tabla g on g.NombreTabla = 'Grado' and g.Codigo = c.GradoId
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
		WHEN c.Profesor like '%'+@Profesor+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Nombre IS NULL THEN 1
		WHEN c.Nombre like '%'+@Nombre+'%' THEN 1
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
		WHEN c.Contenido like '%'+@Contenido+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Competencia IS NULL THEN 1
		WHEN c.Competencia like '%'+@Competencia+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @Capacidad IS NULL THEN 1
		WHEN c.Capacidad like '%'+@Capacidad+'%' THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @TemaContenido IS NULL THEN 1
		WHEN c.TemaContenido like '%'+@TemaContenido+'%' THEN 1
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
		WHEN c.Indicador like '%'+@Indicador+'%' THEN 1
		ELSE 0
	END = 1
ORDER BY c.ClaseId DESC

end

go


create proc sp_tabla_list
	@nombreTabla nvarchar(50),
	@codigoPadre int = null
as
begin

select *
from dbo.Tabla t
where t.NombreTabla = @nombreTabla
	AND CASE
		WHEN @codigoPadre IS NULL THEN 1
		WHEN t.CodigoPadre = @codigoPadre THEN 1
		ELSE 0
	END = 1

end

go


-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar prueba por clase
-- =============================================
CREATE PROCEDURE dbo.[sp_usuario_getByid]
	@usuario_id int
AS
BEGIN

SELECT [UsuarioId],[Usuario],[Nombres],[Apematerno]
  ,[Apepaterno],[Pass],[Correo],[ColegioId]
  ,[EsActivo],(select c.ColegioNombre from colegio c where c.colegioid = u.colegioid) colegio
FROM  [Usuario] u
where u.UsuarioId = @usuario_id

END

GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 13-07-2014
-- Description:	Lista usuario por colegio
-- =============================================
create PROCEDURE dbo.[sp_usuario_lstByColegio]
	@ColegioId as int
AS
BEGIN
	SET NOCOUNT ON;

SELECT     [UsuarioId]
      ,tb1.[Usuario]
      ,tb1.[Nombres]
      ,tb1.[Apematerno]
      ,tb1.[Apepaterno]
      ,tb1.[Correo]
	  ,tb1.ColegioId
      ,tb2.[ColegioNombre] colegio
      ,tb1.[EsActivo]
FROM  [Usuario] as tb1
inner join Colegio as tb2 on tb1.ColegioId=tb2.ColegioId
where tb1.ColegioId=@ColegioId  
END


GO


-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar prueba por clase
-- =============================================
CREATE PROCEDURE dbo.[sp_usuario_lstByUsuarioAndPass]
	@usuario as nvarchar(50),
	@pass as nvarchar(50)
AS
BEGIN

SELECT [UsuarioId],[Usuario],[Nombres],[Apematerno]
  ,[Apepaterno],[Pass],[Correo],[ColegioId]
  ,[EsActivo],(select c.ColegioNombre from colegio c where c.colegioid = u.colegioid) colegio FROM  Usuario u
where usuario =@usuario and PWDCOMPARE(@pass, pass)=1 and [EsActivo]=1

END


GO



CREATE PROCEDURE dbo.sp_clase_lista_profesor
AS
BEGIN

SELECT distinct Profesor from [dbo].[Clase]

END



GO

