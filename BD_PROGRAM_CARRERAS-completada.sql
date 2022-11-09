set dateformat 'DMY'
go
create database TP_PROGRAMACION_CARRERAS
go
use TP_PROGRAMACION_CARRERAS
go
------
create table Barrios(
id_barrio int identity(1,1),
barrio varchar(20)
Constraint pk_barrio primary key(id_barrio)
)
GO
------
create table Tipo_Documentos(
id_tipo_doc int identity(1,1),
tipo_doc varchar(20)
Constraint pk_tipo_doc primary key(id_tipo_doc))
GO
------
create table Carreras (
id_carrera int identity(1,1),
nombre varchar(50),
duracion float
constraint pk_carrera primary key(id_carrera))
GO
------
create table Personas(
id_persona int identity(1,1),
nombre varchar(20),
apellido varchar(20),
id_barrio int,
calle varchar(20),
altura int, 
celular bigint,
id_tipo_doc int,
nro_doc bigint
constraint pk_persona primary key(id_persona),
constraint fk_barrio foreign key(id_barrio)
  references Barrios(id_barrio),
constraint fk_tipo_doc foreign key(id_tipo_doc)
 references Tipo_Documentos(id_tipo_doc))
 GO
 ------
create table Profesores(
legajo int not null,
id_persona int,
fec_contrato DateTime
Constraint pk_legajo primary key(legajo),
Constraint fk_persona foreign key(id_persona)
 references Personas (id_persona))
 GO
 ------
Create table alumnos (
legajo int not null,
id_persona int
constraint pk_legajo_alumno primary key (legajo),
constraint fk_persona_alumno foreign key(id_persona)
references Personas(id_persona))
 GO
 ------
 Create table inscripciones(
id_inscripcion int identity(1,1),
fecha datetime,
legajo int,
curso int, 
constraint pk_inscripcion primary key(id_inscripcion),
constraint fk_legajo foreign key (legajo)
references Alumnos (legajo))
GO
------
create table Materias(
id_materia int identity(1,1),
nombre varchar(50),
legajo int
constraint pk_materia primary key(id_materia),
constraint fk_legajo_profesor	 foreign key(legajo)
references Profesores(legajo))
GO
-----
Create Table Detalle_Inscripciones(
id_detalle int identity(1,1),
id_inscripcion int,
id_carrera int,
id_materia int,
baja_inscripcion varchar(10)
Constraint pk_detalle primary key (id_detalle),
constraint fk_carrera_detalle foreign key(id_carrera)
references carreras(id_carrera),
constraint fk_materia_detalle foreign key (id_materia)
references materias(id_materia),
constraint fk_detalle_inscripcion foreign key(id_inscripcion)
references inscripciones(id_inscripcion))

GO
----------------------Inserts--------------------------------------
---------------------INSERT BARRIOS (42)------------------------------------
insert into Barrios(barrio)
values ('ALBERDI')
insert into Barrios(barrio)
values ('ACOSTA')
insert into Barrios(barrio)
values ('ALBORADA SUR')
insert into Barrios(barrio)
values ('ALBERTO')
insert into Barrios(barrio)
values ('ALTA CORDOBA')
insert into Barrios(barrio)
values ('ALTOS SAN MARTIN')
insert into Barrios(barrio)
values ('BETANIA')
insert into Barrios(barrio)
values ('BOEDO')
insert into Barrios(barrio)
values ('BELLA VISTA')
insert into Barrios(barrio)
values ('BAJO GALAN')
insert into Barrios(barrio)
values ('CACERES')
insert into Barrios(barrio)
values ('CARBO')
insert into Barrios(barrio)
values ('CASEROS')
insert into Barrios(barrio)
values ('CENTRO')
insert into Barrios(barrio)
values ('DEAN FUNES')
insert into Barrios(barrio)
values ('DUCASSE')
insert into Barrios(barrio)
values ('EMPALME')
insert into Barrios(barrio)
values ('ESCOBAR')
insert into Barrios(barrio)
values ('EMAUS')
insert into Barrios(barrio)
values ('FERREYRA')
insert into Barrios(barrio)
values ('FERRER')
insert into Barrios(barrio)
values ('GENERAL PAZ')
insert into Barrios(barrio)
values ('GÜEMES')
insert into Barrios(barrio)
values ('HIPOLITO YRIGOYEN')
insert into Barrios(barrio)
values ('INDEPENDENCIA')
insert into Barrios(barrio)
values ('ITUZAINGO')
insert into Barrios(barrio)
values ('JARDIN')
insert into Barrios(barrio)
values ('JUAN B JUSTO')
insert into Barrios(barrio)
values ('KENNEDY')
insert into Barrios(barrio)
values ('LA FLORESTA')
insert into Barrios(barrio)
values ('MITRE')
insert into Barrios(barrio)
values ('MULLER')
insert into Barrios(barrio)
values ('NUEVA CORDOBA')
insert into Barrios(barrio)
values ('OBRERO')
insert into Barrios(barrio)
values ('PALMAR')
insert into Barrios(barrio)
values ('PROVIDENCIA')
insert into Barrios(barrio)
values ('RIVADAVIA')
insert into Barrios(barrio)
values ('RIVERA INDARTE')
insert into Barrios(barrio)
values ('SAN MARTIN')
insert into Barrios(barrio)
values ('SARMIENTO')
insert into Barrios(barrio)
values ('VILLA BUSTOS')
insert into Barrios(barrio)
values ('YAPEYU')
------------------INSERT DOCUMENTOS (3)------------------------------------
insert into Tipo_Documentos(tipo_doc)
values('LIBRETA CIVICA')
insert into Tipo_Documentos(tipo_doc)
values('DNI')
insert into Tipo_Documentos(tipo_doc)
values('PASAPORTE')
------------------INSERT PERSONAS (64)-----------------------------------------
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('EXEQUIEL','SANTORO',5,'AARON CASTELLANOS',2555,NULL,2,33856)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('NICOLAS','SENESTRARI',6,'URITORCO',4813,NULL,2,421044)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('POSTILLON','CAMILA',5,'TUCUMAN',1200,3548562312,2,444754)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('IMANOL','SUPPO',8,'SAN JERONIMO',3840,3515362613,2,42160)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FRANCO','LENTINI',12,'9 DE JULIO',1563,3514978549,2,44674)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ADRIANA','HERNANDEZ',25,'25 DE MAYO',1245,NULL,2,42160)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ALEJANDRO','ACEVEDO',11,'AVENIDA FUERZA AEREA',1365,354815,2,44664)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ANGELICA','BLANCO',12,'ITUZAINGO',1548,NULL,2,44469)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CAROLINA','PINZON',13,'AV DUARTE QUIROS',628,351789,2,175965)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DANIEL','GOMEZ',14,'DEAN FUNES',159,1132612,2,218659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CLAUDIA','TORRES',15,'SANTA ROSA',987,NULL,2,444659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DANIELA','BRAVO',16,'TUCUMAN',789,NULL,3,421665)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DANIELA','GUZMAN',17,'ENTRE RIOS',654,NULL,2,420720)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CRISTINA','BARTHEL',18,'AV COLON',956,NULL,2,422920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FABIAN','ANDRADE',19,'TUCUMAN',845,NULL,3,231920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GABRIEL','MORENO',20,'27 DE ABRIL',623,351254,2,110920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GLORIA','MENDOZA',21,'URITORCO',1524,NULL,2,423920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GABRIEL','NIETO',22,'AV RAFAEL NUÑES',3261,NULL,2,320920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CINTHYA','DELGADO',23,'CORDOBA',1542,NULL,2,221620)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('LILIANA','PUERTO',24,'AV VELEZ SARFIELD',1563,NULL,3,267950)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FELIPE','BELTRAN',25,'AV EDEN',156,NULL,2,426236)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CARLOS','CALDERIN',26,'BELGRANO',623,NULL,2,31659863)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DIEGO','AVILES',27,'AV ARGENTINA',3459,3548537,2,18963)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ALEJANDRO','DIAZ',28,'PATRIA',1258,NULL,2,23894)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ESTEBAN','BUSTOS',29,'SARMIENTO',2365,NULL,2,201635)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('HUGO','BARRERA',30,'CAPITAL FEDERAL',3468,NULL,2,432156)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JENNY','SANCHEZ',31,'SAN JERONIMO',2659,NULL,2,194596)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('TOMAS','SILVA',32,'CARLOS GARDEL',4545,1123596,2,445326)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CHRISTIAN','OROZCO',33,'CASSAFOUST',1156,NULL,2,446515)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('SEBASTIAN','ORTEGA',34,'BALCARCE',4512,3512475,2,192545)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('AGUSTINA','ORTEGA',35,'CHACABUCO',1236,NULL,3,203329)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JAZMIN','PRECIADO',36,'BUENOS AIRES',4516,NULL,2,446523)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('LAURA','SUAREZ',37,'KENNEDY',693,NULL,2,216521)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('TATIANA','GARCIA',38,'BV ARTURO ILLIA',1236,NULL,2,221659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('NATALIA','RODRIGUEZ',39,'CASEROS',4521,NULL,2,446872)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PIA','RODRIAGUEZ',40,'COLOMBRES',2563,NULL,2,233916)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FRANCISCO','ROJAS',41,'COMECHINGONES',4321,351698,2,238954)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARTIN','MEJIA',42,'BV LAS HERAS',1234,354367,2,413945)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARIA','CATILLO',13,'CERRITO',2456,39637,2,183957)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARGARITA','RAMIREZ',14,'COLOMBIA',478,NULL,2,20168)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARIO','SOLANO',15,'DOMINGO FUNES',263,NULL,2,29663)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PABLO','ORJUELA',16,'ESTADOS UNIDOS',962,NULL,2,28659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('RICARDO','CORREA',10,'ESPORA',5623,NULL,2,271593)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('SANDRA','VEGA',5,'ENTRE RIOS',654,NULL,2,26196)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('SEBASTIAN','ZAMBRANO',4,'ALLENDE',1265,NULL,2,269348)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('VIVIANA','MELGUIZO',12,'GRAL PAZ',578,NULL,2,296318)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('OSCAR','PAEZ',21,'URITORCO',450,351568,2,325923)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('NATALIA','PUENTES',15,'GRAL LAVALLEJA',739,135902,2,369216)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARCELA','REY',10,'GRAL MANUEL BELGRANO',1352,NULL,2,365489)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ANDRES','OCHOA',14,'IGUALDAD',185,35489,2,351284)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FELIPE','COSTA',1,'INDEPENDENCIA',2150,359678,2,349851)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MELINA','SPAREDES',2,'ITUZAINGO',3600,NULL,2,331632)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MAXIMO','MURUA',3,'JOSE BAIGORRI',1512,35126,1,89621)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('IGNACIO', 'OLIVA',4,'JERONIMO CORTEZ',512,NULL,2,396348)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JAVIER','MOYANO',5,'JOSE CORTES FUNES',623,354623,2,309862)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GABRIELA','MONROY',8,'DEAN FUNES',819,354898,2,326963)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('AGIE','BOTERO',25,'LA RIOJA',2200,112458,2,29634)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CAROLINA','CRUZ',23,'MAESTRO VIDAL',1356,165986,2,59638)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ENRIQUE','BORTOLIN',9,'MARIANO MORENO',424,351298,2,439874)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PATRICIA','CONTRETAS',10,'LAPRIDA',659,3514853,2,158963)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ANTONELLA','GUARDIOLA',12,'LA TABLADA',452,3268965,1,296358)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MAILEN','TORRES',14,'LIMA',815,35435,2,22569)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JOAQUIN','POSTILLON',13,'LIBERTAD',1123,335596,2,239789)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PAULA','ODDO',6,'PARAGUAY',3265,354859,2,245139)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FABRIZIO','RODRIGUEZ',20,'RIO NEGRO',327,5963266,2,416548)
------------------INSERT PROFESORES (9)-----------------------------------------
insert into Profesores(legajo,id_persona,fec_contrato)
values(001,5,'11/05/2018')
insert into Profesores(legajo,id_persona,fec_contrato)
values(002,8,'13/06/2017')
insert into Profesores(legajo,id_persona,fec_contrato)
values(003,9,'10/01/2015')
insert into Profesores(legajo,id_persona,fec_contrato)
values(004,6,'11/05/2018')
insert into Profesores(legajo,id_persona,fec_contrato)
values(005,21,'08/03/2010')
insert into Profesores(legajo,id_persona,fec_contrato)
values(006,26,'10/05/2017')
insert into Profesores(legajo,id_persona,fec_contrato)
values(007,12,'01/01/2013')
insert into Profesores(legajo,id_persona,fec_contrato)
values(008,13,'05/05/2020')
insert into Profesores(legajo,id_persona,fec_contrato)
values(009,14,'06/02/2012')
insert into Profesores(legajo,id_persona,fec_contrato)
values(010,15,'01/03/2011')
------------------INSERT ALUMNOS (17)-----------------------------------------
insert into Alumnos(legajo,id_persona)
values(113904,1)
insert into Alumnos(legajo,id_persona)
values(113905,2)
insert into Alumnos(legajo,id_persona)
values(113906,3)
insert into Alumnos(legajo,id_persona)
values(113907,4)
insert into Alumnos(legajo,id_persona)
values(113908,7)
insert into Alumnos(legajo,id_persona)
values(113909,10)
insert into Alumnos(legajo,id_persona)
values(113910,11)
insert into Alumnos(legajo,id_persona)
values(113911,16)
insert into Alumnos(legajo,id_persona)
values(113912,17)
insert into Alumnos(legajo,id_persona)
values(113913,18)
insert into Alumnos(legajo,id_persona)
values(113914,19)
insert into Alumnos(legajo,id_persona)
values(113915,20)
insert into Alumnos(legajo,id_persona)
values(113916,21)
insert into Alumnos(legajo,id_persona)
values(113917,22)
insert into Alumnos(legajo,id_persona)
values(113918,23)
insert into Alumnos(legajo,id_persona)
values(113919,24)
insert into Alumnos(legajo,id_persona)
values(113920,25)
insert into Alumnos(legajo,id_persona)
values(113921,26)
------------------INSERT MATERIAS (17)------------------------------------
insert into Materias(nombre,legajo)
values('LCI',001)
insert into Materias(nombre,legajo)
values('LCII',002)
insert into Materias(nombre,legajo)
values('LEGISLACION',003)
insert into Materias(nombre,legajo)
values('MATEMATICA I',004)
insert into Materias(nombre,legajo)
values('METEMATICA II',005)
insert into Materias(nombre,legajo)
values('INGLES I',006)
insert into Materias(nombre,legajo)
values('INGLES II',007)
insert into Materias(nombre,legajo)
values('ASO',008)
insert into Materias(nombre,legajo)
values('SISTEMA DE PROCESAMIENTO DE DATOS',009)
insert into Materias(nombre,legajo)
values('PROGRAMACION I',009)
insert into Materias(nombre,legajo)
values('PROGRAMACION II',001)
insert into Materias(nombre,legajo)
values('ANALISIS MATEMATICO',002)
insert into Materias(nombre,legajo)
values('ALGEBRA',003)
insert into Materias(nombre,legajo)
values('FISICA',004)
insert into Materias(nombre,legajo)
values('ELECTROTECNIA',005)
insert into Materias(nombre,legajo)
values('CONTABILIDAD',006)
insert into Materias(nombre,legajo)
values('MARCO JURIDICO',007)
-------------------------------------------------------------------------
------------------INSERT CARRERAS (2)------------------------------------
insert into Carreras(nombre, duracion)
values('TECNICATURA EN PROGRAMACIÓN',2)
insert into Carreras(nombre, duracion)
values('INGENIERIA CIVIL',6)


-----------------------------------------------------------------------------
-----------------------------STORE PROCEDURE-----------------------------------
GO
CREATE proc [dbo].[SP_baja_inscripcion]
@id_detalle int
as
update detalle_inscripciones
set baja_inscripcion = 'true'
where id_detalle = @id_detalle
GO

create proc [dbo].[SP_combo_legajo]
as
select legajo from alumnos
GO

create proc [dbo].[SP_CONSULTAR_BARRIOS]
as 
select*from Barrios
GO

create proc [dbo].[SP_consultar_carreras]
as
select * from carreras
GO

create proc [dbo].[SP_consultar_inscripcion_año]
@id_materia int = 0
as
if @id_materia = 0
select YEAR(fecha), COUNT(*) from inscripciones
group by YEAR(fecha)
else
select YEAR(fecha), COUNT(*) from inscripciones i
join detalle_inscripciones di on di.id_inscripcion=i.id_inscripcion
where di.id_materia=@id_materia
group by YEAR(fecha)
GO

create proc [dbo].[SP_consultar_legajo]
@legajo int
as
select legajo from alumnos where legajo=@legajo
GO

create proc [dbo].[sp_consultar_materias]
as
select *from Materias
GO

create proc [dbo].[SP_CONSULTAR_TIPO_DOC]
as
select*from Tipo_Documentos
GO

CREATE procedure [dbo].[SP_Insert_detalle]
@id_inscripcion int,
@id_carrera int,
@id_materia int
as
insert into Detalle_Inscripciones(id_inscripcion,id_carrera,id_materia,baja_inscripcion)
values (@id_inscripcion,@id_carrera,@id_materia,'false')
GO

create procedure [dbo].[SP_Insert_inscripcion]
@fecha datetime,
@legajo int,
@curso int,
@id_inscripcion int output
as
insert into inscripciones(fecha,legajo,curso)
values (@fecha,@legajo, @curso)
set @id_inscripcion = SCOPE_IDENTITY();
GO

CREATE procedure [dbo].[SP_insertar_alumno]
@id_persona int,
@legajo int
as
begin
insert into alumnos(legajo,id_persona) values (@legajo,@id_persona)
end
GO

create procedure [dbo].[SP_Insertar_persona]
@nombre varchar(50),
@apellido varchar(50),
@id_barrio int,
@calle varchar(50),
@altura varchar(50),
@celular bigint,
@id_tipo_doc int,
@nro_doc bigint,
@nro_persona int output,
@legajo int output
as
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values(@nombre,@apellido,@id_barrio,@calle,@altura,@celular,@id_tipo_doc,@nro_doc)
set @nro_persona = SCOPE_IDENTITY();
set @legajo = (select max(legajo) + 1 from alumnos);
GO

create proc [dbo].[SP_modificar_usuario]
@nombre varchar(50),
@apellido varchar(50),
@telefono bigint,
@tipo_doc int,
@doc bigint,
@barrio int,
@calle varchar(50),
@altura int,
@legajo int
as
update Personas
set nombre=@nombre, apellido=@apellido, celular=@telefono, id_tipo_doc=@tipo_doc, nro_doc=@doc, id_barrio=@barrio, calle=@calle, altura=@altura
where id_persona=(select id_persona from alumnos where legajo=@legajo)
GO

create proc [dbo].[SP_Obtener_Alumnos]
@nombre varchar(50)=null,
@apellido varchar(50)=null
as
if @nombre is not null and @apellido is not null
select a.legajo Legajo, UPPER(LEFT(p.nombre,1))+LOWER(RIGHT(p.nombre,LEN(p.nombre)-1))+SPACE(1)+UPPER(LEFT(p.apellido,1))+LOWER(RIGHT(p.apellido,LEN(p.apellido)-1)) Nombre_Completo, p.calle+space(1)+LTRIM(STR(p.altura)) Direccion, p.celular Telefono
from alumnos a 
join personas p on p.id_persona=a.id_persona
where p.nombre=@nombre and p.apellido=@apellido 
else
if @nombre is not null or @apellido is not null
select a.legajo Legajo, UPPER(LEFT(p.nombre,1))+LOWER(RIGHT(p.nombre,LEN(p.nombre)-1))+SPACE(1)+UPPER(LEFT(p.apellido,1))+LOWER(RIGHT(p.apellido,LEN(p.apellido)-1)) Nombre_Completo, p.calle+space(1)+LTRIM(STR(p.altura)) Direccion, p.celular Telefono
from alumnos a 
join personas p on p.id_persona=a.id_persona
where p.nombre=@nombre or p.apellido=@apellido
else
select a.legajo Legajo, UPPER(LEFT(p.nombre,1))+LOWER(RIGHT(p.nombre,LEN(p.nombre)-1))+SPACE(1)+UPPER(LEFT(p.apellido,1))+LOWER(RIGHT(p.apellido,LEN(p.apellido)-1)) Nombre_Completo, p.calle+space(1)+LTRIM(STR(p.altura)) Direccion, p.celular Telefono
from alumnos a 
join personas p on p.id_persona=a.id_persona
GO

CREATE procedure [dbo].[SP_obtener_detalles]
@legajo int = null,
@fecha_desde datetime = null,
@fecha_hasta datetime = null
as
if(@legajo is not null and @fecha_desde is not null and @fecha_hasta is not null)
begin
select i.legajo, c.nombre 'carrera', m.nombre 'materia', det.id_detalle
from inscripciones i join Detalle_Inscripciones det on i.id_inscripcion = det.id_inscripcion
join Carreras c on c.id_carrera = det.id_carrera
join Materias m on m.id_materia = det.id_materia
where i.legajo = @legajo and i.fecha between @fecha_desde and @fecha_hasta and det.baja_inscripcion='false'
end
if(@legajo is null and @fecha_desde is not null and @fecha_hasta is not null)
begin
select i.legajo, c.nombre 'carrera', m.nombre 'materia', det.id_detalle
from inscripciones i join Detalle_Inscripciones det on i.id_inscripcion = det.id_inscripcion
join Carreras c on c.id_carrera = det.id_carrera
join Materias m on m.id_materia = det.id_materia
where i.fecha between @fecha_desde and @fecha_hasta and det.baja_inscripcion='false'
end
if(@legajo is not null and @fecha_desde is null and @fecha_hasta is null)
begin
select i.legajo, c.nombre 'carrera', m.nombre 'materia', det.id_detalle
from inscripciones i join Detalle_Inscripciones det on i.id_inscripcion = det.id_inscripcion
join Carreras c on c.id_carrera = det.id_carrera
join Materias m on m.id_materia = det.id_materia
where i.legajo = @legajo and det.baja_inscripcion='false'
end
if(@legajo is null and @fecha_desde is null and @fecha_hasta is null)
begin
select i.legajo, c.nombre 'carrera', m.nombre 'materia', det.id_detalle
from inscripciones i join Detalle_Inscripciones det on i.id_inscripcion = det.id_inscripcion
join Carreras c on c.id_carrera = det.id_carrera
join Materias m on m.id_materia = det.id_materia
where det.baja_inscripcion='false'
end
GO

create procedure [dbo].[SP_proximo_legajo]
@next int output
as
begin
set @next = (select max(legajo) + 1 from alumnos)
end
GO


