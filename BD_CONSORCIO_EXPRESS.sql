DROP PROCEDURE REGISTRAR_USUARIO
DROP TABLE COMPRAS
SELECT * FROM USUARIO_NUEVO
DELETE FROM USUARIO_NUEVO WHERE IdCodigoUsuario = 105

--CREAR BASE DE DATOS
CREATE DATABASE DBCONSORCIO_EXPRESS

--USAR BASE DE DATOS DBCONSORCIO_EXPRESS
USE DBCONSORCIO_EXPRESS

--CREAMOS LAS TABLAS DE LA BASE DE DATOS

CREATE TABLE USUARIO_NUEVO
(
	IdCodigoUsuario varchar(15) not null,
	Documento varchar(20),
	Nombres varchar(80),
	Apellidos varchar(80),	
	Telefono varchar(30),
	Correo varchar(80),
	Cargo varchar(40),
	Contrasena varchar (50),
	--ConfirmarContrasena varchar (50)
)

CREATE TABLE ADMINISTRADOR
(
	IdAdministrador varchar(15) not null,
	Documento varchar(20),
	Nombres varchar(80),
	Apellidos varchar(80),
	Telefono varchar(30),
	Correo varchar(80)
)

CREATE TABLE PROVEEDOR
(
	IdProveedor varchar(15) not null,
	NitProveedor varchar(20),
	NombreProveedor varchar(80),
	Direccion varchar(80),
	Telefono varchar(30),
	Correo varchar(80)
)

CREATE TABLE VEHICULO
(
	NumeroBus varchar(15) not null,
	IdAdministrador varchar(15) not null,
	ModeloBus varchar(15),
	NumeroPasajeros varchar(15),
	Placa varchar(15)
)

CREATE TABLE CONDUCTOR
(
	IdConductor varchar(15) not null,
	IdAdministrador varchar(15) not null,
	Documento varchar(20),
	Nombres varchar(80),
	Apellidos varchar(80)
)

CREATE TABLE COMPRAS
(
	NumeroFactura varchar(15) not null,
	NombreProveedor varchar(100),
	NitProveedor varchar(15) not null,
	Dirección varchar(80),
	Telefono varchar(15),
	Correo varchar(100),
	NombreArticulo varchar(80),
	Cantidad int,
	Total int,
	Fecha datetime
)

CREATE TABLE ARTICULO
(
	IdArticulo varchar(15) not null,
	NombreProducto varchar(80),
	Total int
)

CREATE TABLE SERVICIO
(
	IdServicio varchar(15) not null,
	Descripcion varchar(200)
)

CREATE TABLE ASIGNAR_RUTAS
(
	IdConductor varchar(15) not null,
	NumeroBus varchar(15) not null,
	IdAdministrador varchar(15) not null,
	Ruta varchar(100),
	Fecha datetime
)

CREATE TABLE REQUERIMIENTO
(
	NumeroBus varchar(15) not null,
	IdServicio varchar(15) not null,
)

CREATE TABLE DETALLE_COMPRA
(
	IdArticulo varchar(15) not null,
	NumeroFactura varchar(15) not null,
	Cantidad int,
	Total int,
	Fecha datetime
)

CLAVES PRIMARIAS

alter table USUARIO_NUEVO
add constraint PK_USUARIO_NUEVO primary key (IdCodigoUsuario)

alter table ADMINISTRADOR
add constraint PK_ADMINISTRADOR primary key (IdAdministrador)

alter table PROVEEDOR
add constraint PK_PROVEEDOR primary key (IdProveedor)

alter table VEHICULO
add constraint PK_VEHICULO primary key (NumeroBus)

alter table CONDUCTOR
add constraint PK_CONDUCTOR primary key (IdConductor)

alter table COMPRAS
add constraint PK_COMPRAS primary key (NumeroFactura)

alter table ARTICULO
add constraint PK_ARTICULO primary key (IdArticulo)

alter table SERVICIO
add constraint PK_SERVICIO primary key (IdServicio)

--CLAVES COMPUESTAS

alter table ASIGNAR_RUTAS
add constraint PK_ASIGNAR_RUTAS primary key (IdConductor,NumeroBus)

alter table REQUERIMIENTO
add constraint PK_REQUERIMIENTO primary key (NumeroBus,IdServicio)

alter table DETALLE_COMPRA
add constraint PK_DETALLE_COMPRA primary key (IdArticulo,NumeroFactura)

--CREAR LLAVES FORANEAS

alter table VEHICULO
add constraint FK_ADMINISTRADOR_VEHICULO foreign key (IdAdministrador)
references ADMINISTRADOR(IdAdministrador)
on delete cascade
on update cascade

alter table COMPRAS
add constraint FK_ADMINISTRADOR_COMPRAS foreign key (IdAdministrador)
references ADMINISTRADOR(IdAdministrador)
on delete cascade
on update cascade

alter table COMPRAS
add constraint FK_PROVEEDOR_COMPRAS foreign key (IdProveedor)
references PROVEEDOR(IdProveedor)
on delete cascade
on update cascade

alter table REQUERIMIENTO
add constraint FK_SERVICIO_REQUERIMIENTO foreign key (IdServicio)
references SERVICIO(IdServicio)
on delete cascade
on update cascade

alter table REQUERIMIENTO
add constraint FK_VEHICULO_REQUERIMIENTO foreign key (NumeroBus)
references VEHICULO(NumeroBus)
on delete cascade
on update cascade

alter table ASIGNAR_RUTAS
add constraint FK_CONDUCTOR_ASIGNAR_RUTAS foreign key (IdConductor)
references CONDUCTOR(IdConductor)
on delete cascade
on update cascade

alter table ASIGNAR_RUTAS
add constraint FK_VEHICULO_ASIGNAR_RUTAS foreign key (NumeroBus)
references VEHICULO(NumeroBus)
on delete cascade
on update cascade

alter table DETALLE_COMPRA
add constraint FK_ARTICULO_DETALLE_COMPRA foreign key (IdArticulo)
references ARTICULO(IdArticulo)
on delete cascade
on update cascade

alter table DETALLE_COMPRA
add constraint FK_COMPRAS_DETALLE_COMPRA foreign key (NumeroFactura)
references COMPRAS(NumeroFactura)
on delete cascade
on update cascade


--PROCEDIMIENTOS ALMACENADOS TABLA USUARIO_NUEVO

--REGISTRAR USUARIO
create procedure REGISTRAR_USUARIO
	@IdCodigoUsuario varchar(15),
	@Documento varchar(20),
	@Nombres varchar(80),
	@Apellidos varchar(80),	
	@Telefono varchar(30),
	@Correo varchar(60),
	@Cargo varchar(40),
	@Contrasena varchar (50)

as
begin
	insert into USUARIO_NUEVO (IdCodigoUsuario,Documento,Nombres,Apellidos,Telefono,Correo,Cargo,Contrasena)
	values (@IdCodigoUsuario,@Documento,@Nombres,@Apellidos,@Telefono,@Correo,@Cargo,@Contrasena)
end

execute REGISTRAR_USUARIO '101','71387351','JUAN CAMILO','PAREJA SANCHEZ','3006315482','JUAN@GMAIL.COM','ADMINISTRADOR','abcd'
execute REGISTRAR_USUARIO '102','32354286','MARIA ANGELICA','ALVARADO TORRES','3014331294','MARIA@GMAIL.COM','GERENTE','abcd'
execute REGISTRAR_USUARIO '103','32517722','MARGARITA','SANCHEZ GARCES','3138482370','MARGARITA@GMAIL.COM','SUPERVISORA','abcd'
execute REGISTRAR_USUARIO '104','42977632','LUZ ESTELA','SANCHEZ GARCES','3007822183','ESTELA@GMAIL.COM','EMPLEADA','abcd'
execute REGISTRAR_USUARIO '105','32851762','JULIO ALFREDO','MUÑOZ PANIAGUA','314974651','JULIO@GMAIL.COM','EMPLEADO','abcd'
execute REGISTRAR_USUARIO '106','71387351','JUAN CAMILO','PAREJA SANCHEZ','3006315482','JUAN@GMAIL.COM','ADMINISTRADOR','abcd'
execute REGISTRAR_USUARIO '107','32354286','MARIA ANGELICA','ALVARADO TORRES','3014331294','MARIA@GMAIL.COM','GERENTE','abcd'
execute REGISTRAR_USUARIO '108','32517722','MARGARITA','SANCHEZ GARCES','3138482370','MARGARITA@GMAIL.COM','SUPERVISORA','abcd'
execute REGISTRAR_USUARIO '109','42977632','LUZ ESTELA','SANCHEZ GARCES','3007822183','ESTELA@GMAIL.COM','EMPLEADA','abcd'
execute REGISTRAR_USUARIO '110','32851762','JULIO ALFREDO','MUÑOZ PANIAGUA','314974651','JULIO@GMAIL.COM','EMPLEADO','abcd'
execute REGISTRAR_USUARIO '111','71387351','JUAN CAMILO','PAREJA SANCHEZ','3006315482','JUAN@GMAIL.COM','ADMINISTRADOR','abcd'
execute REGISTRAR_USUARIO '112','32354286','MARIA ANGELICA','ALVARADO TORRES','3014331294','MARIA@GMAIL.COM','GERENTE','abcd'
execute REGISTRAR_USUARIO '113','32517722','MARGARITA','SANCHEZ GARCES','3138482370','MARGARITA@GMAIL.COM','SUPERVISORA','abcd'
execute REGISTRAR_USUARIO '114','42977632','LUZ ESTELA','SANCHEZ GARCES','3007822183','ESTELA@GMAIL.COM','EMPLEADA','abcd'
execute REGISTRAR_USUARIO '115','32851762','JULIO ALFREDO','MUÑOZ PANIAGUA','314974651','JULIO@GMAIL.COM','EMPLEADO','abcd'
execute REGISTRAR_USUARIO '116','71387351','JUAN CAMILO','PAREJA SANCHEZ','3006315482','JUAN@GMAIL.COM','ADMINISTRADOR','abcd'
execute REGISTRAR_USUARIO '117','32354286','MARIA ANGELICA','ALVARADO TORRES','3014331294','MARIA@GMAIL.COM','GERENTE','abcd'
execute REGISTRAR_USUARIO '118','32517722','MARGARITA','SANCHEZ GARCES','3138482370','MARGARITA@GMAIL.COM','SUPERVISORA','abcd'
execute REGISTRAR_USUARIO '119','42977632','LUZ ESTELA','SANCHEZ GARCES','3007822183','ESTELA@GMAIL.COM','EMPLEADA','abcd'
execute REGISTRAR_USUARIO '120','32851762','JULIO ALFREDO','MUÑOZ PANIAGUA','314974651','JULIO@GMAIL.COM','EMPLEADO','abcd'


--ACTUALIZAR USUARIO
create procedure ACTUALIZAR_USUARIO
	@IdCodigoUsuario varchar(15),
	@Documento varchar(20),
	@Nombres varchar(80),
	@Apellidos varchar(80),	
	@Telefono varchar(30),
	@Correo varchar(60),
	@Cargo varchar(40),
	@Contrasena varchar (500)
	--@ConfirmarContrasena varchar (500),

as
begin
	update USUARIO_NUEVO set IdCodigoUsuario=@IdCodigoUsuario,Documento=@Documento,Nombres=@Nombres,Apellidos=@Apellidos
	,Telefono=@Telefono,Correo=@Correo,Cargo=@Cargo,Contrasena=@Contrasena where IdCodigoUsuario=@IdCodigoUsuario
end

execute ACTUALIZAR_USUARIO '101','71387351','JUAN CAMILO','ORTIZ SANCHEZ','3006315482','JUAN@HOTMAIL.COM','CONDUCTOR','12345'

--CONSULTAR USUARIO
create procedure CONSULTAR_USUARIO
	@IdCodigoUsuario varchar(15)
as
begin
	select IdCodigoUsuario,Documento,Nombres,Apellidos,Telefono,Correo,Cargo,Contrasena from USUARIO_NUEVO where IdCodigoUsuario=@IdCodigoUsuario
end

execute CONSULTAR_USUARIO '102'

--LISTAR USUARIOS
create procedure LISTAR_USUARIOS
as
begin
	select IdCodigoUsuario,Documento,Nombres,Apellidos,Telefono,Correo,Cargo,Contrasena	from USUARIO_NUEVO
end

execute LISTAR_USUARIOS

--ELIMINAR USUARIO
create procedure ELIMINAR_USUARIO
	@IdCodigoUsuario varchar(20)
as
begin
	delete from USUARIO_NUEVO where IdCodigoUsuario=@IdCodigoUsuario
end

execute ELIMINAR_USUARIO '101'
execute ELIMINAR_USUARIO '102'
execute ELIMINAR_USUARIO '103'
execute ELIMINAR_USUARIO '104'
execute ELIMINAR_USUARIO '105'
execute ELIMINAR_USUARIO ''


execute LISTAR_USUARIOS


--PROCEDIMIENTOS ALMACENADOS TABLA PROVEEDOR

--REGISTRAR PROVEEDOR
create procedure REGISTRAR_PROVEEDOR
	@IdProveedor varchar(15),
	@NitProveedor varchar(20),
	@NombreProveedor varchar(80),
	@Direccion varchar(80),
	@Telefono varchar(30),
	@Correo varchar(80)

as
begin
	insert into PROVEEDOR (IdProveedor,NitProveedor,NombreProveedor,Direccion,Telefono,Correo)
	values (@IdProveedor,@NitProveedor,@NombreProveedor,@Direccion,@Telefono,@Correo)
end

execute REGISTRAR_PROVEEDOR '1538','900156487-1','CAUCHOS S.A','CR 23 56C 12','3418725','cauchossa@hotmail.com'
execute REGISTRAR_PROVEEDOR '1540','900156487-1','CAUCHOS S.A','CR 23 56C 12','5640219','cauchossa@hotmail.com'
execute REGISTRAR_PROVEEDOR '1542','900156487-1','CAUCHOS S.A','CR 23 56C 12','5640219','cauchossa@hotmail.com'
execute REGISTRAR_PROVEEDOR '1544','900156487-1','CAUCHOS S.A','CR 23 56C 12','5640219','cauchossa@hotmail.com'

--ACTUALIZAR PROVEEDOR
create procedure ACTUALIZAR_PROVEEDOR
	@IdProveedor varchar(15),
	@NitProveedor varchar(20),
	@NombreProveedor varchar(80),
	@Direccion varchar(80),
	@Telefono varchar(30),
	@Correo varchar(80)

as
begin
	update PROVEEDOR set IdProveedor=@IdProveedor,NitProveedor=@NitProveedor,NombreProveedor=@NombreProveedor,Direccion=@Direccion,Telefono=@Telefono,Correo=@Correo
						where IdProveedor=@IdProveedor
end

execute ACTUALIZAR_PROVEEDOR '1538','900156487-1','CAUCHOS S.A','CR 23 56C 12','5640219','cauchossa@hotmail.com'

--CONSULTAR PROVEEDOR
create procedure CONSULTAR_PROVEEDOR
	@IdProveedor varchar(15)
as
begin
	select IdProveedor,NitProveedor,NombreProveedor,Direccion,Telefono,Correo from PROVEEDOR where IdProveedor=@IdProveedor
end

execute CONSULTAR_PROVEEDOR '1540'

--LISTAR PROVEEDOR
create procedure LISTAR_PROVEEDOR
as
begin
	select IdProveedor,NitProveedor,NombreProveedor,Direccion,Telefono,Correo from PROVEEDOR
end

execute LISTAR_PROVEEDOR

--ELIMINAR PROVEEDOR
create procedure ELIMINAR_PROVEEDOR
	@IdProveedor varchar(15)
as
begin
	delete from PROVEEDOR where IdProveedor=@IdProveedor
end

execute ELIMINAR_PROVEEDOR ''


--PROCEDIMIENTOS ALMACENADOS TABLA ADMINISTRADOR

--REGISTRAR ADMINISTRADOR
create procedure REGISTRAR_ADMINISTRADOR
	@IdAdministrador varchar(15),
	@Documento varchar(20),
	@Nombres varchar(80),
	@Apellidos varchar(80),
	@Telefono varchar(30),
	@Correo varchar(80)

as
begin
	insert into ADMINISTRADOR (IdAdministrador,Documento,Nombres,Apellidos,Telefono,Correo)
	values (@IdAdministrador,@Documento,@Nombres,@Apellidos,@Telefono,@Correo)
end

execute REGISTRAR_ADMINISTRADOR '101','71387351','JUAN CAMILO','PAREJA SANCHEZ','3006315482','JUAN@GMAIL.COM'

select * from ADMINISTRADOR

--PENDIENTE LOS OTROS PROCEDIMIENTOS DE LA TABLA ADMINISTRADOR


--PROCEDIMIENTOS ALMACENADOS TABLA VEHICULO

--REGISTRAR VEHICULO
create procedure REGISTRAR_VEHICULO
	@NumeroBus varchar(15),
	@IdAdministrador varchar(15),
	@ModeloBus varchar(15),
	@NumeroPasajeros varchar(15),
	@Placa varchar(15)

as
begin
	insert into VEHICULO (NumeroBus,IdAdministrador,ModeloBus,NumeroPasajeros,Placa)
	values (@NumeroBus,@IdAdministrador,@ModeloBus,@NumeroPasajeros,@Placa)
end

execute REGISTRAR_VEHICULO '235','101','2022','30','HVD 982'
execute REGISTRAR_VEHICULO '236','101','2020','30','HVD 348'
execute REGISTRAR_VEHICULO '237','101','2019','30','HVD 761'
execute REGISTRAR_VEHICULO '238','101','2018','30','HVD 824'
execute REGISTRAR_VEHICULO '239','101','2024','30','HVD 647'

select * from VEHICULO

--ACTUALIZAR VEHICULO
create procedure ACTUALIZAR_VEHICULO
	@NumeroBus varchar(15),
	@IdAdministrador varchar(15),
	@ModeloBus varchar(15),
	@NumeroPasajeros varchar(15),
	@Placa varchar(15)

as
begin
	update VEHICULO set NumeroBus=@NumeroBus,IdAdministrador=@IdAdministrador,ModeloBus=@ModeloBus,NumeroPasajeros=@NumeroPasajeros,Placa=@Placa
						where NumeroBus=@NumeroBus
end

execute ACTUALIZAR_VEHICULO '235','101','2020','30','HVD 982'

--CONSULTAR VEHICULO
create procedure CONSULTAR_VEHICULO
	@NumeroBus varchar(15)
as
begin
	select NumeroBus,IdAdministrador,ModeloBus,NumeroPasajeros,Placa from VEHICULO where NumeroBus=@NumeroBus
end

execute CONSULTAR_VEHICULO '235'

--LISTAR VEHICULO
create procedure LISTAR_VEHICULO
as
begin
	select NumeroBus,IdAdministrador,ModeloBus,NumeroPasajeros,Placa from VEHICULO
end

execute LISTAR_VEHICULO

--ELIMINAR VEHICULO
create procedure ELIMINAR_VEHICULO
	@NumeroBus varchar(15)
as
begin
	delete from VEHICULO where NumeroBus=@NumeroBus
end

execute ELIMINAR_VEHICULO '235'


--PROCEDIMIENTOS ALMACENADOS TABLA CONDUCTOR

--REGISTRAR CONDUCTOR
create procedure REGISTRAR_CONDUCTOR
	@IdConductor varchar(15),
	@IdAdministrador varchar(15),
	@Documento varchar(20),
	@Nombres varchar(80),
	@Apellidos varchar(80)

as
begin
	insert into CONDUCTOR (IdConductor,IdAdministrador,Documento,Nombres,Apellidos)
	values (@IdConductor,@IdAdministrador,@Documento,@Nombres,@Apellidos)
end

execute REGISTRAR_CONDUCTOR '125','101','26457985','JUAN CARLOS','LOPEZ SANCHEZ'

select * from CONDUCTOR

--PENDIENTE LOS OTROS PROCEDIMIENTOS DE LA TABLA CONDUCTOR


--PROCEDIMIENTOS ALMACENADOS TABLA COMPRAS
	NumeroFactura varchar(15) not null,
	NombreProveedor varchar(100),
	NitProveedor varchar(15) not null,
	Dirección varchar(80),
	Telefono varchar(15),
	Correo varchar(100),
	NombreArticulo varchar(80),
	Cantidad int,
	Total int,
	Fecha datetime
--REGISTRAR COMPRAS
create procedure REGISTRAR_COMPRAS
	@NumeroFactura varchar(15),
	@NombreProveedor varchar(100),
	@NitProveedor varchar(15),
	@Dirección varchar(80),
	@Telefono varchar(15),
	@Correo varchar(100),
	@NombreArticulo varchar(80),
	@Cantidad int,
	@Total int,
	@Fecha datetime

as
begin
	insert into COMPRAS (NumeroFactura,NombreProveedor,NitProveedor,Dirección,Telefono,Correo,NombreArticulo,Cantidad,Total,Fecha)
	values (@NumeroFactura,@NombreProveedor,@NitProveedor,@Dirección,@Telefono,@Correo,@NombreArticulo,@Cantidad,@Total,@Fecha)
end

set dateformat dmy

execute REGISTRAR_COMPRAS '00513','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','300654956','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'
execute REGISTRAR_COMPRAS '00514','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','300654956','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'
execute REGISTRAR_COMPRAS '00515','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','300654956','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'
execute REGISTRAR_COMPRAS '00516','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','300654956','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'
execute REGISTRAR_COMPRAS '00517','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','300654956','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'
execute REGISTRAR_COMPRAS '00518','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','300654956','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'
execute REGISTRAR_COMPRAS '00519','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','300654956','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'

select * from COMPRAS

--ACTUALIZAR COMPRAS
create procedure ACTUALIZAR_COMPRAS
	@NumeroFactura varchar(15),
	@NombreProveedor varchar(100),
	@NitProveedor varchar(15),
	@Dirección varchar(80),
	@Telefono varchar(15),
	@Correo varchar(100),
	@NombreArticulo varchar(80),
	@Cantidad int,
	@Total int,
	@Fecha datetime

as
begin
	update COMPRAS set NumeroFactura=@NumeroFactura,NombreProveedor=@NombreProveedor,NitProveedor=@NitProveedor,Dirección=@Dirección,
	Telefono=@Telefono,Correo=@Correo,NombreArticulo=@NombreArticulo,Cantidad=@Cantidad,Total=@Total,Fecha=@Fecha where NumeroFactura=@NumeroFactura
	
end

execute ACTUALIZAR_COMPRAS '00513','LLANTAS COLOMBIA','99056418-1','CALLE 31 # 81A 51','1111111111','LLANTASCOLOMBIA@GMAIL.COM','LLANTAS X 4','100','2000000','15-03-2024'

--CONSULTAR COMPRAS
create procedure CONSULTAR_COMPRAS
	@NumeroFactura varchar(15)
as
begin
	select NumeroFactura,NombreProveedor,NitProveedor,Dirección,Telefono,Correo,NombreArticulo,Cantidad,Total,Fecha from COMPRAS
	where NumeroFactura=@NumeroFactura
end

execute CONSULTAR_COMPRAS '00513'

--LISTAR COMPRAS
create procedure LISTAR_COMPRAS
as
begin
	select NumeroFactura,NombreProveedor,NitProveedor,Dirección,Telefono,Correo,NombreArticulo,Cantidad,Total,Fecha from COMPRAS
end

execute LISTAR_COMPRAS

--ELIMINAR COMPRAS
create procedure ELIMINAR_COMPRAS
	@NumeroFactura varchar(15)
as
begin
	delete from COMPRAS where NumeroFactura=@NumeroFactura
end

execute ELIMINAR_COMPRAS '00513'


--PROCEDIMIENTOS ALMACENADOS TABLA ARTICULO

--REGISTRAR ARTICULO
create procedure REGISTRAR_ARTICULO
	@IdArticulo varchar(15),
	@NombreProducto varchar(80),
	@Total int

as
begin
	insert into ARTICULO (IdArticulo,NombreProducto,Total)
	values (@IdArticulo,@NombreProducto,@Total)
end

execute REGISTRAR_ARTICULO 'XBL0522','EMPAQUE DE MOTOR','62000'
execute REGISTRAR_ARTICULO 'XBL645','EMPAQUE DE MOTOR','80000'
execute REGISTRAR_ARTICULO 'LH6215','EMPAQUE DE MOTOR','100000'
execute REGISTRAR_ARTICULO 'RX942GH','EMPAQUE DE MOTOR','20000'
execute REGISTRAR_ARTICULO 'RE3254','EMPAQUE DE MOTOR','40000'

select * from ARTICULO

--ACTUALIZAR ARTICULO
create procedure ACTUALIZAR_ARTICULO
	@IdArticulo varchar(15),
	@NombreProducto varchar(80),
	@Total int

as
begin
	update ARTICULO set IdArticulo=@IdArticulo,NombreProducto=@NombreProducto,Total=@Total where IdArticulo=@IdArticulo
end

execute ACTUALIZAR_ARTICULO 'XBL0522','EMPAQUE DE MOTOR','70000'


--CONSULTAR ARTICULO
create procedure CONSULTAR_ARTICULO
	@IdArticulo varchar(15)
as
begin
	select IdArticulo,NombreProducto,Total from ARTICULO where IdArticulo=@IdArticulo
end

execute CONSULTAR_ARTICULO 'XBL0522'

--LISTAR ARTICULO
create procedure LISTAR_ARTICULO
as
begin
	select IdArticulo,NombreProducto,Total from ARTICULO
end

execute LISTAR_ARTICULO

--ELIMINAR ARTICULO
create procedure ELIMINAR_ARTICULO
	@IdArticulo varchar(15)
as
begin
	delete from ARTICULO where IdArticulo=@IdArticulo
end

execute ELIMINAR_ARTICULO 'XBL0522'


--PROCEDIMIENTOS ALMACENADOS TABLA SERVICIO

--REGISTRAR SERVICIO
create procedure REGISTRAR_SERVICIO
	@IdServicio varchar(15),
	@Descripcion varchar(200)

as
begin
	insert into SERVICIO (IdServicio,Descripcion)
	values (@IdServicio,@Descripcion)
end

execute REGISTRAR_SERVICIO '01','SERVICIO PÚBLICO URBANO DE PASAJEROS'

select * from SERVICIO

--ACTUALIZAR SERVICIO
create procedure ACTUALIZAR_SERVICIO
	@IdServicio varchar(15),
	@Descripcion varchar(200)

as
begin
	update SERVICIO set IdServicio=@IdServicio,Descripcion=@Descripcion where IdServicio=@IdServicio
end

execute ACTUALIZAR_SERVICIO '01','SERVICIO PRIVADO URBANO DE PASAJEROS'

--CONSULTAR SERVICIO
create procedure CONSULTAR_SERVICIO
	@IdServicio varchar(15)
as
begin
	select IdServicio,Descripcion from SERVICIO where IdServicio=@IdServicio
end

execute CONSULTAR_SERVICIO '01'

--LISTAR SERVICIO
create procedure LISTAR_SERVICIO
as
begin
	select IdServicio,Descripcion from SERVICIO
end

execute LISTAR_SERVICIO

--ELIMINAR SERVICIO
create procedure ELIMINAR_SERVICIO
	@IdServicio varchar(15)
as
begin
	delete from SERVICIO where IdServicio=@IdServicio
end

execute ELIMINAR_SERVICIO '01'


--PROCEDIMIENTOS ALMACENADOS TABLA ASIGNAR_RUTAS

--REGISTRAR RUTAS
create procedure REGISTRAR_RUTAS
	@IdConductor varchar(15),
	@NumeroBus varchar(15),
	@IdAdministrador varchar(15),
	@Ruta varchar(100),
	@Fecha datetime

as
begin
	insert into ASIGNAR_RUTAS (IdConductor,NumeroBus,IdAdministrador,Ruta,Fecha)
	values (@IdConductor,@NumeroBus,@IdAdministrador,@Ruta,@Fecha)
end

set dateformat dmy

execute REGISTRAR_RUTAS '125','235','101','PARADERO PRINCIPAL-CENTRO','23-06-2024'

select * from ASIGNAR_RUTAS

--ACTUALIZAR RUTAS
create procedure ACTUALIZAR_RUTAS
	@IdConductor varchar(15),
	@NumeroBus varchar(15),
	@IdAdministrador varchar(15),
	@Ruta varchar(100),
	@Fecha datetime

as
begin
	update ASIGNAR_RUTAS set IdConductor=@IdConductor,NumeroBus=@NumeroBus,IdAdministrador=@IdAdministrador,Ruta=@Ruta,Fecha=@Fecha
							where IdConductor=@IdConductor
end

execute ACTUALIZAR_RUTAS '125','235','101','PARADERO PRINCIPAL-POBLADO','23-06-2024'

--CONSULTAR RUTAS
create procedure CONSULTAR_RUTAS
	@IdConductor varchar(15)
as
begin
	select IdConductor,NumeroBus,IdAdministrador,Ruta,Fecha from ASIGNAR_RUTAS where IdConductor=@IdConductor
end

execute CONSULTAR_RUTAS '125'

--LISTAR RUTAS
create procedure LISTAR_RUTAS
as
begin
	select IdConductor,NumeroBus,IdAdministrador,Ruta,Fecha from ASIGNAR_RUTAS
end

execute LISTAR_RUTAS

--ELIMINAR RUTAS
create procedure ELIMINAR_RUTAS
	@IdConductor varchar(15)
as
begin
	delete from ASIGNAR_RUTAS where IdConductor=@IdConductor
end

execute ELIMINAR_RUTAS '125'


--PROCEDIMIENTOS ALMACENADOS TABLA REQUERIMIENTO

--REGISTRAR REQUERIMIENTO
create procedure REGISTRAR_REQUERIMIENTO
	@NumeroBus varchar(15),
	@IdServicio varchar(15)

as
begin
	insert into REQUERIMIENTO (NumeroBus,IdServicio)
	values (@NumeroBus,@IdServicio)
end

execute REGISTRAR_REQUERIMIENTO '235','01'

select * from REQUERIMIENTO

--PENDIENTE LOS OTROS PROCEDIMIENTOS DE LA TABLA REQUERIMIENTO


--PROCEDIMIENTOS ALMACENADOS TABLA DETALLE_COMPRA

--REGISTRAR DETALLE COMPRA
create procedure REGISTRAR_DETALLE_COMPRA
	@IdArticulo varchar(15),
	@NumeroFactura varchar(15),
	@Cantidad int,
	@Total int,
	@Fecha datetime

as
begin
	insert into DETALLE_COMPRA (IdArticulo,NumeroFactura,Cantidad,Total,Fecha)
	values (@IdArticulo,@NumeroFactura,@Cantidad,@Total,@Fecha)
end

set dateformat dmy

execute REGISTRAR_DETALLE_COMPRA 'XBL0522','000513','10','620000','23-06-2024'

select * from DETALLE_COMPRA

--ACTUALIZAR DETALLE COMPRA
create procedure ACTUALIZAR_DETALLE_COMPRA
	@IdArticulo varchar(15),
	@NumeroFactura varchar(15),
	@Cantidad int,
	@Total int,
	@Fecha datetime

as
begin
	update DETALLE_COMPRA set IdArticulo=@IdArticulo,NumeroFactura=@NumeroFactura,Cantidad=@Cantidad,Total=@Total,Fecha=@Fecha
							where IdArticulo=@IdArticulo
end

execute ACTUALIZAR_DETALLE_COMPRA 'XBL0522','000513','100','6200000','23-06-2024'

--CONSULTAR DETALLE COMPRA
create procedure CONSULTAR_DETALLE_COMPRA
	@IdArticulo varchar(15)
as
begin
	select IdArticulo,NumeroFactura,Cantidad,Total,Fecha from DETALLE_COMPRA where IdArticulo=@IdArticulo
end

execute CONSULTAR_DETALLE_COMPRA 'XBL0522'

--LISTAR DETALLE COMPRA
create procedure LISTAR_DETALLE_COMPRA
as
begin
	select IdArticulo,NumeroFactura,Cantidad,Total,Fecha from DETALLE_COMPRA
end

execute LISTAR_DETALLE_COMPRA

--ELIMINAR DETALLE COMPRA
create procedure ELIMINAR_DETALLE_COMPRA
	@IdArticulo varchar(15)
as
begin
	delete from DETALLE_COMPRA where IdArticulo=@IdArticulo
end

execute ELIMINAR_DETALLE_COMPRA 'XBL0522'