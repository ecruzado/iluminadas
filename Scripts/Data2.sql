use Iluminada
go

---- Competencia Lv
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('CompetenciaLv', 1, 'Competencia 1', null, 1)

---- Capacidad Lv
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('CapacidadLv', 1, 'Capacidad 1', 1, 1)

---- Metodologia Lv
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('MetodologiaLv', 1, 'Metodologia 1', null, 1)

---- Titulo Lv
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('TituloLv', 1, 'Titulo 1', null, 1)

---- Tema Lv
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('TemaLv', 1, 'Tema 1', 1, 1)

---- Virtud General
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('VirtudGeneral', 1, 'Virtud General 1', null, 1)

---- Virtud Especifica
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('VirtudEspecifica', 1, 'Virtud Especifica 1', 1, 1)


---- Colegio
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Colegio', 1, 'Colegio 1', null, 1)
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Colegio', 2, 'Colegio 2', null, 1)

---- Area
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Area', 1, 'Area 1', null, 1)
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Area', 2, 'Are 2', null, 1)


---- Nivel
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Nivel', 1, 'Nivel 1', 1, 1)
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Nivel', 2, 'Nivel 2', 2, 1)

---- Grado
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Grado', 1, 'Area 1', 1, 1)
insert into Tabla(NombreTabla, Codigo, Valor, CodigoPadre, EsActivo)
values ('Grado', 2, 'Are 2', 2, 1)