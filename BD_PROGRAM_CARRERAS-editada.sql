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
references materias(id_materia))

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
values('EXEQUIEL','SANTORO',5,'AARON CASTELLANOS',2555,NULL,2,33856925)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('NICOLAS','SENESTRARI',6,'URITORCO',4813,NULL,2,42160920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('POSTILLON','CAMILA',5,'TUCUMAN',1200,3548562312,2,44474054)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('IMANOL','SUPPO',8,'SAN JERONIMO',3840,3515362613,2,42160720)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FRANCO','LENTINI',12,'9 DE JULIO',1563,3514978549,2,44659874)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ADRIANA','HERNANDEZ',25,'25 DE MAYO',1245,NULL,2,42160920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ALEJANDRO','ACEVEDO',11,'AVENIDA FUERZA AEREA',1365,3548562315,2,44661874)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ANGELICA','BLANCO',12,'ITUZAINGO',1548,NULL,2,44465659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CAROLINA','PINZON',13,'AV DUARTE QUIROS',628,3512635789,2,17551965)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DANIEL','GOMEZ',14,'DEAN FUNES',159,113265912,2,21874659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CLAUDIA','TORRES',15,'SANTA ROSA',987,NULL,2,44454659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DANIELA','BRAVO',16,'TUCUMAN',789,NULL,3,42162365)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DANIELA','GUZMAN',17,'ENTRE RIOS',654,NULL,2,42160720)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CRISTINA','BARTHEL',18,'AV COLON',956,NULL,2,42172920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FABIAN','ANDRADE',19,'TUCUMAN',845,NULL,3,23160920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GABRIEL','MORENO',20,'27 DE ABRIL',623,3512636954,2,21160920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GLORIA','MENDOZA',21,'URITORCO',1524,NULL,2,42360920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GABRIEL','NIETO',22,'AV RAFAEL NUÑES',3261,NULL,2,32160920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CINTHYA','DELGADO',23,'CORDOBA',1542,NULL,2,22167920)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('LILIANA','PUERTO',24,'AV VELEZ SARFIELD',1563,NULL,3,22167950)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FELIPE','BELTRAN',25,'AV EDEN',156,NULL,2,42659236)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CARLOS','CALDERIN',26,'BELGRANO',623,NULL,2,31659863)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('DIEGO','AVILES',27,'AV ARGENTINA',3459,3548569637,2,18455963)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ALEJANDRO','DIAZ',28,'PATRIA',1258,NULL,2,23659894)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ESTEBAN','BUSTOS',29,'SARMIENTO',2365,NULL,2,20159635)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('HUGO','BARRERA',30,'CAPITAL FEDERAL',3468,NULL,2,43261156)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JENNY','SANCHEZ',31,'SAN JERONIMO',2659,NULL,2,19456596)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('TOMAS','SILVA',32,'CARLOS GARDEL',4545,112348596,2,44659326)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CHRISTIAN','OROZCO',33,'CASSAFOUST',1156,NULL,2,44659215)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('SEBASTIAN','ORTEGA',34,'BALCARCE',4512,3512489675,2,19265465)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('AGUSTINA','ORTEGA',35,'CHACABUCO',1236,NULL,3,20331329)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JAZMIN','PRECIADO',36,'BUENOS AIRES',4516,NULL,2,44659123)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('LAURA','SUAREZ',37,'KENNEDY',693,NULL,2,21659321)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('TATIANA','GARCIA',38,'BV ARTURO ILLIA',1236,NULL,2,22321659)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('NATALIA','RODRIGUEZ',39,'CASEROS',4521,NULL,2,44659872)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PIA','RODRIAGUEZ',40,'COLOMBRES',2563,NULL,2,23378916)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FRANCISCO','ROJAS',41,'COMECHINGONES',4321,3512639698,2,23168954)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARTIN','MEJIA',42,'BV LAS HERAS',1234,3548532367,2,41326945)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARIA','CATILLO',13,'CERRITO',2456,3548596237,2,18346957)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARGARITA','RAMIREZ',14,'COLOMBIA',478,NULL,2,20159368)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARIO','SOLANO',15,'DOMINGO FUNES',263,NULL,2,29659863)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PABLO','ORJUELA',16,'ESTADOS UNIDOS',962,NULL,2,28612359)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('RICARDO','CORREA',10,'ESPORA',5623,NULL,2,27159823)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('SANDRA','VEGA',5,'ENTRE RIOS',654,NULL,2,26147896)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('SEBASTIAN','ZAMBRANO',4,'ALLENDE',1265,NULL,2,25169348)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('VIVIANA','MELGUIZO',12,'GRAL PAZ',578,NULL,2,24596318)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('OSCAR','PAEZ',21,'URITORCO',450,3515689421,2,38125923)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('NATALIA','PUENTES',15,'GRAL LAVALLEJA',739,112635902,2,37569216)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MARCELA','REY',10,'GRAL MANUEL BELGRANO',1352,NULL,2,36125489)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ANDRES','OCHOA',14,'IGUALDAD',185,3548562389,2,35126984)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FELIPE','COSTA',1,'INDEPENDENCIA',2150,3512459678,2,34629851)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MELINA','SPAREDES',2,'ITUZAINGO',3600,NULL,2,33159632)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MAXIMO','MURUA',3,'JOSE BAIGORRI',1512,3512638426,1,32489621)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('IGNACIO', 'OLIVA',4,'JERONIMO CORTEZ',512,NULL,2,31596348)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JAVIER','MOYANO',5,'JOSE CORTES FUNES',623,3548595623,2,30159862)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('GABRIELA','MONROY',8,'DEAN FUNES',819,3548956238,2,35126963)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('AGIE','BOTERO',25,'LA RIOJA',2200,112458966,2,25159634)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('CAROLINA','CRUZ',23,'MAESTRO VIDAL',1356,113265986,2,40159638)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ENRIQUE','BORTOLIN',9,'MARIANO MORENO',424,351263598,2,43269874)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PATRICIA','CONTRETAS',10,'LAPRIDA',659,3514859693,2,20158963)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('ANTONELLA','GUARDIOLA',12,'LA TABLADA',452,3543268965,1,21596358)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('MAILEN','TORRES',14,'LIMA',815,3548596235,2,22563159)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('JOAQUIN','POSTILLON',13,'LIBERTAD',1123,3512635596,2,23159789)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('PAULA','ODDO',6,'PARAGUAY',3265,3548532659,2,24512639)
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
values('FABRIZIO','RODRIGUEZ',20,'RIO NEGRO',327,3515963266,2,43216548)
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


------------------INSERT INSCRIPCIONES [FALTAN]------------------------------------
insert into inscripciones (fecha,legajo,curso) values('01/03/2022',113904,null)
insert into inscripciones (fecha,legajo,curso) values('01/03/2022',113905,1)
insert into inscripciones (fecha,legajo,curso) values('20/01/2022',113906,1)
insert into inscripciones (fecha,legajo,curso) values('20/02/2022',113907,1)
insert into inscripciones (fecha,legajo,curso) values('15/02/2022',113908,2)
insert into inscripciones (fecha,legajo,curso) values('20/02/2022',113909,2)
insert into inscripciones (fecha,legajo,curso) values('03/03/2022',113910,1)
insert into inscripciones (fecha,legajo,curso) values('25/01/2022',113911,1)
insert into inscripciones (fecha,legajo,curso) values('20/11/2021',113912,1)
insert into inscripciones (fecha,legajo,curso) values('19/11/2021',113913,1)
insert into inscripciones (fecha,legajo,curso) values('28/02/2022',113914,2)
insert into inscripciones (fecha,legajo,curso) values('02/03/2022',113915,2)
insert into inscripciones (fecha,legajo,curso) values('25/01/2022',113916,2)
insert into inscripciones (fecha,legajo,curso) values('05/03/2022',113917,2)
insert into inscripciones (fecha,legajo,curso) values('29/11/2021',113918,2)
insert into inscripciones (fecha,legajo,curso) values('17/02/2022',113919,2)
insert into inscripciones (fecha,legajo,curso) values('14/02/2022',113920,2)
insert into inscripciones (fecha,legajo,curso) values('10/11/2021',113921,2)


------------------INSERT DETALLE INSCRIPCION [FALTAN]-------------------------------
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(20,3,1,2)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(21,7,1,3)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(22,5,1,4)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(23,4,1,5)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(24,1,1,6)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(25,12,1,7)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(26,13,2,8)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(27,16,2,9)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(28,17,2,10)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(29,14,2,11)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(30,13,2,12)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(31,12,2,13)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(32,2,1,14)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(33,3,1,15)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(34,4,1,16)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(35,5,1,17)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(36,14,2,18)
insert into Detalle_Inscripciones(id_inscripcion,id_materia,id_carrera,baja_inscripcion) values(37,16,2,19)


----CREACION DE SP'S---------
-----------OBTENER PROXIMO LEGAJO----------------
go
create procedure SP_proximo_legajo
@next int output
as
begin
set @next = (select max(legajo) + 1 from alumnos)
end


---------Crear funcion proximo legajo--------------
/*create function f_proximo_legajo
()
returns int
as 
begin 
declare @legajo int
set @legajo = (select max(legajo) + 1 from alumnos)
return @legajo
end

select dbo.f_proximo_legajo()*/
go
----------------------------------------------------------------
------------INSERTAR USUARIO------------------
create procedure SP_insertar_usuario
@nombre varchar(50),
@apellido varchar(50),
@telefono bigint,
@tipo_doc int,
@nro_documento bigint,
@id_barrio int,
@calle int,
@altura int,
@id int output
as
begin 
insert into Personas(nombre,apellido,id_barrio,calle,altura,celular,id_tipo_doc,nro_doc)
			values(@nombre,@apellido,@id_barrio,@calle,@altura,@telefono,@tipo_doc,@nro_documento)
	set @id = SCOPE_IDENTITY();
end
go
------------INSERTAR ALUMNO----------------------
create procedure SP_insertar_alumno
@id int,
@legajo int
as
begin
insert into alumnos(legajo,id_persona)
		values (@legajo,@id)
end
go
-----------------------------------------------------
------SP CONSULTAR USUARIOS----------
create proc SP_consultar_usuarios
@legajo int null,
@condicion varchar(10) null
as
begin
if (@condicion = 'Alumno' and @legajo is null)
	begin
		select a.legajo, p.nombre + ' ' + p.apellido, trim(p.calle) + ' N°: ' + trim(str(p.altura)), p.celular
		from Personas p join alumnos a on a.id_persona = p.id_persona
	end				
if (@condicion = 'Profesor' and @legajo is null)
	begin
		select pro.legajo, p.nombre + ' ' + p.apellido, trim(p.calle) + ' N°: ' + trim(str(p.altura)), p.celular
		from Personas p join Profesores pro on pro.id_persona = p.id_persona
	end	
if (@condicion = 'Alumno' and @legajo is not null)
	begin
		select a.legajo, p.nombre + ' ' + p.apellido, trim(p.calle) + ' N°: ' + trim(str(p.altura)), p.celular
		from Personas p join alumnos a on a.id_persona = p.id_persona
		where a.legajo = @legajo
	end	
if (@condicion = 'Profesor' and @legajo is not null)
	begin
		select pro.legajo, p.nombre + ' ' + p.apellido, trim(p.calle) + ' N°: ' + trim(str(p.altura)), p.celular
		from Personas p join Profesores pro on pro.id_persona = p.id_persona
		where pro.legajo = @legajo
	end	
end

go
create proc SP_consultar_carreras
as
select * from carreras

GO
create proc sp_consultar_materias
as
select *from Materias

GO
create procedure SP_Insert_inscripcion
@fecha datetime,
@legajo int,
@curso int,
@id_inscripcion int output
as
insert into inscripciones(fecha,legajo,curso)
values (@fecha,@legajo, @curso)
set @id_inscripcion = SCOPE_IDENTITY();

GO
create procedure SP_Insert_detalle
@id_inscripcion int,
@id_carrera int,
@id_materia int
as
insert into Detalle_Inscripciones(id_inscripcion,id_carrera,id_materia)
values (@id_inscripcion,@id_carrera,@id_materia)
----Consulta del grafico-----
SELECT p.nombre+','+p.apellido 'Alumno', m.nombre 'Materia', c.nombre 'Carrera' FROM Detalle_Inscripciones d
JOIN inscripciones i on i.id_inscripcion = d.id_inscripcion
join Materias m on m.id_materia = d.id_materia
join Carreras c on c.id_carrera = d.id_carrera
join alumnos a on a.legajo = i.legajo
join Personas p on p.id_persona = a.id_persona
order by p.nombre
